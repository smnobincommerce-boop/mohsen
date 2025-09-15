'use strict';
var steelstoree = function () {
var steel9 = $(function () {
    $("button[name=milgerd]").click(function () {
        if ($(this).val() == "milgerd1") {

            $("#divmilgerd").show();
            $("#divvaragh").hide();
            $("#divbar").hide();
            $("#divloole").hide();
            $("#divtir").hide();
            $("#divprofil").hide();
            $("#divorginal").hide();
        }

    });
});
var steel10 = $(function () {
    $("button[name=bar]").click(function () {
        if ($(this).val() == "bar1") {

            $("#divmilgerd").hide();
            $("#divvaragh").hide();
            $("#divbar").show();
            $("#divloole").hide();
            $("#divtir").hide();
            $("#divprofil").hide();
            $("#divorginal").hide();
        }
    });
});
var steel11 = $(function () {
    $("button[name=varagh]").click(function () {
        if ($(this).val() == "varagh1") {

            $("#divmilgerd").hide();
            $("#divvaragh").show();
            $("#divbar").hide();
            $("#divloole").hide();
            $("#divtir").hide();
            $("#divprofil").hide();
            $("#divorginal").hide();
        }
    });
});
var steel12 = $(function () {
    $("button[name=loole]").click(function () {
        if ($(this).val() == "loole1") {

            $("#divmilgerd").hide();
            $("#divvaragh").hide();
            $("#divbar").hide();
            $("#divloole").show();
            $("#divtir").hide();
            $("#divprofil").hide();
            $("#divorginal").hide();
        }
    });
});
var steel13 = $(function () {
    $("button[name=tir]").click(function () {

        if ($(this).val() == "tir1") {

            $("#divmilgerd").hide();
            $("#divvaragh").hide();
            $("#divbar").hide();
            $("#divloole").hide();
            $("#divtir").show();
            $("#divprofil").hide();
            $("#divorginal").hide();
        }
    });
});
var steel14 = $(function () {
    $("button[name=profil]").click(function () {
        if ($(this).val() == "profil1") {

            $("#divmilgerd").hide();
            $("#divvaragh").hide();
            $("#divbar").hide();
            $("#divloole").hide();
            $("#divtir").hide();
            $("#divprofil").show();
            $("#divorginal").hide();
        }
    });

});

}();