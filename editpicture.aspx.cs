using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip; // برای DotNetZip


namespace WebApplicationImpora2222025.panel.maneger
{
    public partial class editpicture : System.Web.UI.Page
    {

       protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FileUploadImages.HasFiles)
                {
                    lblMessage.Text = "لطفاً حداقل یک تصویر انتخاب کنید.";
                    return;
                }

                // دریافت و اعتبارسنجی ورودی‌ها
                int targetWidth = 600; // پیش‌فرض عرض
                int targetHeight = 900; // پیش‌فرض ارتفاع
                long targetSize = 400 * 1024; // پیش‌فرض حجم (400 کیلوبایت)

                int width = 0; // تعریف متغیر قبل از TryParse
                if (!string.IsNullOrWhiteSpace(txtWidth.Text) && int.TryParse(txtWidth.Text, out width) && width > 0)
                {
                    targetWidth = width;
                }

                // اعتبارسنجی ارتفاع
                int height = 0; // تعریف متغیر قبل از TryParse
                if (!string.IsNullOrWhiteSpace(txtHeight.Text) && int.TryParse(txtHeight.Text, out height) && height > 0)
                {
                    targetHeight = height;
                }

                // اعتبارسنجی حداکثر حجم
                long maxSize = 0; // تعریف متغیر قبل از TryParse
                if (!string.IsNullOrWhiteSpace(txtMaxSize.Text) && long.TryParse(txtMaxSize.Text, out maxSize) && maxSize > 0)
                {
                    targetSize = maxSize * 1024; // تبدیل به بایت
                }

                // پوشه موقت برای ذخیره تصاویر پردازش‌شده
                string tempFolder = Server.MapPath("~/TempImages/");
                if (!Directory.Exists(tempFolder))
                {
                    Directory.CreateDirectory(tempFolder);
                }

                List<string> processedImagePaths = new List<string>();

                // پردازش هر تصویر
                foreach (HttpPostedFile uploadedFile in FileUploadImages.PostedFiles)
                {
                    string extension = Path.GetExtension(uploadedFile.FileName).ToLower();
                    if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(extension))
                    {
                        lblMessage.Text = "فقط فایل‌های JPG و PNG مجاز هستند.";
                        return;
                    }

                    if (uploadedFile.ContentLength > 10 * 1024 * 1024) // حداکثر 10 مگابایت
                    {
                        lblMessage.Text = "اندازه فایل " + uploadedFile.FileName + " بیش از حد مجاز است.";
                        return;
                    }

                    // نام فایل ایمن
                    string safeFileName = Guid.NewGuid().ToString() + ".jpg";
                    string outputPath = Path.Combine(tempFolder, safeFileName);

                    // تغییر اندازه تصویر
                    using (Stream stream = uploadedFile.InputStream)
                    using (System.Drawing.Image originalImage = System.Drawing.Image.FromStream(stream))
                    {
                        // ایجاد تصویر جدید با ابعاد هدف
                        using (Bitmap newImage = new Bitmap(targetWidth, targetHeight))
                        using (Graphics graphics = Graphics.FromImage(newImage))
                        {
                            // تنظیمات کیفیت بالا
                            graphics.CompositingQuality = CompositingQuality.HighQuality;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.SmoothingMode = SmoothingMode.HighQuality;

                            // پر کردن پس‌زمینه با سفید
                            graphics.Clear(Color.White);

                            // محاسبه نسبت تصویر برای بزرگ‌نمایی یا کوچک‌نمایی
                            double ratioX = (double)targetWidth / originalImage.Width;
                            double ratioY = (double)targetHeight / originalImage.Height;
                            double ratio = Math.Min(ratioX, ratioY); // برای کوچک‌نمایی یا بزرگ‌نمایی

                            int newWidth = (int)(originalImage.Width * ratio);
                            int newHeight = (int)(originalImage.Height * ratio);

                            // اگر تصویر کوچک‌تر از ابعاد هدف است، بزرگ‌نمایی انجام شود
                            if (originalImage.Width < targetWidth || originalImage.Height < targetHeight)
                            {
                                newWidth = (int)(originalImage.Width * ratio);
                                newHeight = (int)(originalImage.Height * ratio);
                            }

                            // قرار دادن تصویر در مرکز
                            int posX = (targetWidth - newWidth) / 2;
                            int posY = (targetHeight - newHeight) / 2;

                            graphics.DrawImage(originalImage, posX, posY, newWidth, newHeight);

                            // تنظیم کیفیت JPEG برای رسیدن به حجم هدف
                            EncoderParameters encoderParams = new EncoderParameters(1);
                            encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 85L);
                            ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageEncoders().First(c => c.MimeType == "image/jpeg");

                            // ذخیره تصویر
                            newImage.Save(outputPath, jpegCodec, encoderParams);
                        }
                    }

                    // بررسی حجم فایل و تنظیم کیفیت در صورت نیاز
                    FileInfo fileInfo = new FileInfo(outputPath);
                    if (fileInfo.Length > targetSize)
                    {
                        long quality = 85;
                        while (fileInfo.Length > targetSize && quality > 10)
                        {
                            quality -= 5;
                            using (System.Drawing.Image tempImage = System.Drawing.Image.FromFile(outputPath))
                            {
                                EncoderParameters encoderParams = new EncoderParameters(1);
                                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                                ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageEncoders().First(c => c.MimeType == "image/jpeg");
                                tempImage.Save(outputPath + ".temp", jpegCodec, encoderParams);
                            }
                            File.Delete(outputPath);
                            File.Move(outputPath + ".temp", outputPath);
                            fileInfo = new FileInfo(outputPath);
                        }
                    }

                    processedImagePaths.Add(outputPath);
                }

                // ایجاد فایل ZIP با DotNetZip
                string zipPath = Path.Combine(tempFolder, "ProcessedImages_" + Guid.NewGuid().ToString() + ".zip");
                using (ZipFile zip = new ZipFile())
                {
                    foreach (string imagePath in processedImagePaths)
                    {
                        zip.AddFile(imagePath, "");
                    }
                    zip.Save(zipPath);
                }

                // دانلود فایل ZIP
                Response.Clear();
                Response.ContentType = "application/zip";
                Response.AddHeader("Content-Disposition", "attachment; filename=ProcessedImages.zip");
                Response.TransmitFile(zipPath);
                Response.Flush();

                // پاکسازی فایل‌های موقت
                foreach (string imagePath in processedImagePaths)
                {
                    if (File.Exists(imagePath))
                        File.Delete(imagePath);
                }
                if (File.Exists(zipPath))
                    File.Delete(zipPath);

                Response.End();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا: " + ex.Message;
                System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
            }
        }
        //protected void btnProcess_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!FileUploadImages.HasFiles)
        //        {
        //            lblMessage.Text = "لطفاً حداقل یک تصویر انتخاب کنید.";
        //            return;
        //        }

        //        // پوشه موقت برای ذخیره تصاویر پردازش‌شده
        //        string tempFolder = Server.MapPath("~/TempImages/");
        //        if (!Directory.Exists(tempFolder))
        //        {
        //            Directory.CreateDirectory(tempFolder);
        //        }

        //        List<string> processedImagePaths = new List<string>();

        //        // پردازش هر تصویر
        //        foreach (HttpPostedFile uploadedFile in FileUploadImages.PostedFiles)
        //        {
        //            string extension = Path.GetExtension(uploadedFile.FileName).ToLower();
        //            if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(extension))
        //            {
        //                lblMessage.Text = "فقط فایل‌های JPG و PNG مجاز هستند.";
        //                return;
        //            }

        //            if (uploadedFile.ContentLength > 10 * 1024 * 1024) // حداکثر 10 مگابایت
        //            {
        //                lblMessage.Text = "اندازه فایل " + uploadedFile.FileName + " بیش از حد مجاز است.";
        //                return;
        //            }

        //            // نام فایل ایمن
        //            string safeFileName = Guid.NewGuid().ToString() + ".jpg";
        //            string outputPath = Path.Combine(tempFolder, safeFileName);

        //            // تغییر اندازه تصویر
        //            using (Stream stream = uploadedFile.InputStream)
        //            using (System.Drawing.Image originalImage = System.Drawing.Image.FromStream(stream))
        //            {
        //                int targetWidth = 900;
        //                int targetHeight = 600;

        //                // ایجاد تصویر جدید با ابعاد 600x900
        //                using (Bitmap newImage = new Bitmap(targetWidth, targetHeight))
        //                using (Graphics graphics = Graphics.FromImage(newImage))
        //                {
        //                    // تنظیمات کیفیت بالا
        //                    graphics.CompositingQuality = CompositingQuality.HighQuality;
        //                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //                    graphics.SmoothingMode = SmoothingMode.HighQuality;

        //                    // پر کردن پس‌زمینه با سفید
        //                    graphics.Clear(Color.White);

        //                    // محاسبه نسبت تصویر برای حفظ aspect ratio
        //                    double ratioX = (double)targetWidth / originalImage.Width;
        //                    double ratioY = (double)targetHeight / originalImage.Height;
        //                    double ratio = Math.Min(ratioX, ratioY);

        //                    int newWidth = (int)(originalImage.Width * ratio);
        //                    int newHeight = (int)(originalImage.Height * ratio);

        //                    // قرار دادن تصویر در مرکز
        //                    int posX = (targetWidth - newWidth) / 2;
        //                    int posY = (targetHeight - newHeight) / 2;

        //                    graphics.DrawImage(originalImage, posX, posY, newWidth, newHeight);

        //                    // تنظیم کیفیت JPEG برای رسیدن به حجم ~400KB
        //                    EncoderParameters encoderParams = new EncoderParameters(1);
        //                    encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 85L);
        //                    ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageEncoders().First(c => c.MimeType == "image/jpeg");

        //                    // ذخیره تصویر
        //                    newImage.Save(outputPath, jpegCodec, encoderParams);
        //                }
        //            }

        //            // بررسی حجم فایل و تنظیم کیفیت در صورت نیاز
        //            FileInfo fileInfo = new FileInfo(outputPath);
        //            long targetSize = 400 * 1024; // 400 کیلوبایت
        //            if (fileInfo.Length > targetSize)
        //            {
        //                long quality = 85;
        //                while (fileInfo.Length > targetSize && quality > 10)
        //                {
        //                    quality -= 5;
        //                    using (System.Drawing.Image tempImage = System.Drawing.Image.FromFile(outputPath))
        //                    {
        //                        EncoderParameters encoderParams = new EncoderParameters(1);
        //                        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
        //                        ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageEncoders().First(c => c.MimeType == "image/jpeg");
        //                        tempImage.Save(outputPath + ".temp", jpegCodec, encoderParams);
        //                    }
        //                    File.Delete(outputPath);
        //                    File.Move(outputPath + ".temp", outputPath);
        //                    fileInfo = new FileInfo(outputPath);
        //                }
        //            }

        //            processedImagePaths.Add(outputPath);
        //        }

        //        // ایجاد فایل ZIP
        //        string zipPath = Path.Combine(tempFolder, "ProcessedImages_" + Guid.NewGuid().ToString() + ".zip");
        //        using (FileStream zipFile = new FileStream(zipPath, FileMode.Create))
        //        using (ZipArchive archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
        //        {
        //            foreach (string imagePath in processedImagePaths)
        //            {
        //                string entryName = Path.GetFileName(imagePath);
        //                ZipArchiveEntry entry = archive.CreateEntry(entryName);
        //                using (Stream entryStream = entry.Open())
        //                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open))
        //                {
        //                    imageStream.CopyTo(entryStream);
        //                }
        //            }
        //        }

        //        // دانلود فایل ZIP
        //        Response.Clear();
        //        Response.ContentType = "application/zip";
        //        Response.AddHeader("Content-Disposition", "attachment; filename=ProcessedImages.zip");
        //        Response.TransmitFile(zipPath);
        //        Response.Flush();

        //        // پاکسازی فایل‌های موقت
        //        foreach (string imagePath in processedImagePaths)
        //        {
        //            if (File.Exists(imagePath))
        //                File.Delete(imagePath);
        //        }
        //        if (File.Exists(zipPath))
        //            File.Delete(zipPath);

        //        Response.End();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMessage.Text = "خطا: " + ex.Message;
        //        System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
        //    }
        //}
        
          protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}