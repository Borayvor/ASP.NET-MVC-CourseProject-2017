$(function () {
    $.validator.setDefaults({
        ignore: ""
    });

    //// =====================================================

    $.validator.addMethod("comparedate", function (value, element, params) {
        var propElementName = params.split(",")[0];
        var operatorName = params.split(",")[1];

        debugger;
        if (params == undefined || params == null || params.length == 0 ||
        value == undefined || value == null || value.length == 0 ||
        propElementName == undefined || propElementName == null || propElementName.length == 0 ||
        operatorName == undefined || operatorName == null || operatorName.length == 0) {
            return true;
        }

        var valueOther = $(propElementName).val();
        var valueFirst = (isNaN(value) ? Date.parse(value) : eval(value));
        var valueSecond = (isNaN(valueOther) ? Date.parse(valueOther) : eval(valueOther));

        if (operatorName == "GreaterThan") {
            return valueFirst > valueSecond;
        }

        if (operatorName == "LessThan") {
            return valueFirst < valueSecond;
        }

        if (operatorName == "GreaterThanOrEqual") {
            return valueFirst >= valueSecond;
        }

        if (operatorName == "LessThanOrEqual") {
            return valueFirst <= valueSecond;
        }
    });

    $.validator.unobtrusive.adapters.add("comparedate",
    ["comparetopropertyname", "operatorname"], function (options) {
        debugger;
        options.rules["comparedate"] = "#" +
        options.params.comparetopropertyname + "," + options.params.operatorname;
        options.messages["comparedate"] = options.message;
    });

    //// =====================================================

    $.validator.unobtrusive.adapters.add('validateimagefile', ['validtypes'], function (options) {
        options.rules['validateimagefile'] = { validtypes: options.params.validtypes.split(',') };
        options.messages['validateimagefile'] = options.message;
    });

    $.validator.addMethod("validateimagefile", function (value, element, param) {
        if (element.files) {
            for (var i = 0; i < element.files.length; i++) {
                var extension = getFileExtension(element.files[0].contentType);

                if ($.inArray(extension, param.validtypes) === -1) {
                    return false;
                }
            }
        }

        var extension = getFileExtension(element[0].contentType);

        if ($.inArray(extension, param.validtypes) === -1) {
            return false;
        }

        return true;
    });

    function getFileExtension(fileName) {
        if (/[/]/.exec(fileName)) {
            return /[^/]+$/.exec(fileName)[0].toLowerCase();
        }
        return null;
    }

    //// =====================================================

    $('#btn-images').click(function (e) {
        $('#Files').click();
    });

    $('#Files').change(function (e) {
        var files = $(this)[0].files;
        var length = files.length;
        var i,
            strResult = "",
            arrResult = [];

        for (i = 0; i < length; i += 1) {
            strResult += files[i].name;
            arrResult.push(files[i].name);

            if (i < length - 1) {
                strResult += ", ";
            }
        }

        $('#readonly-images').val(strResult);
    });

    $('#btn-cover-image').click(function (e) {
        $('#CoverImage').click();
    });

    $('#CoverImage').change(function (e) {
        var strResult = $(this)[0].files[0].name;

        $('#readonly-cover-image').val(strResult);
    });

    $('#CreateNewPhotocourse').submit(function (e) {
       
        if (!$(this).valid()) {
            return;
        }

        $("#loading").show();
        var url = $(this).attr("action");
        var formData = $(this);

        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            processData: false,
            contentType: false
        })
    });
});