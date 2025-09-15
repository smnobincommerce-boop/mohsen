document.addEventListener("DOMContentLoaded", function () {
    let textElement = document.getElementById("typing-text");
    let text = "چه کمکی از دست من برمیاد؟";
    let index = 0;
    let repeatCount = 0;
    const maxRepeats = 3;

    function typeEffect() {
        if (index < text.length) {
            textElement.innerHTML += text.charAt(index);
            textElement.style.visibility = "visible";
            index++;
            setTimeout(typeEffect, 100);
        } else {
            if (repeatCount < maxRepeats - 1) {  // اگر کمتر از ۳ بار اجرا شده
                setTimeout(resetAndRepeat, 20000); // بعد از ۲۰ ثانیه پاک شود
            }
        }
    }

    function resetAndRepeat() {
        textElement.innerHTML = ""; // متن را پاک کن
        index = 0; // مقدار ایندکس را ریست کن
        repeatCount++; // تعداد دفعات اجرا را افزایش بده
        setTimeout(typeEffect, 500); // مجدد تایپ کن
    }

    if (window.innerWidth <= 991) {
        textElement.innerHTML = ""; // اطمینان از خالی بودن متن در شروع
        setTimeout(typeEffect, 500); // اولین بار اجرا شود
    }
});
