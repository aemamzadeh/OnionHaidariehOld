var SinglePage = {};

SinglePage.LoadModal = function () {
    var url = window.location.hash.toLowerCase();
    if (!url.startsWith("#showmodal")) {
        return;
    }
    url = url.split("showmodal=")[1];
    $.get(url,
        null,
        function (htmlPage) {
            $("#ModalContent").html(htmlPage);
            const container = document.getElementById("ModalContent");
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
            showModal();
        }).fail(function (error) {
            alert("خطایی رخ داده، لطفا با مدیر سیستم تماس بگیرید.");
        });
};

function showModal() {
    $("#MainModal").modal("show");
}

function hideModal() {
    $("#MainModal").modal("hide");
}

$(document).ready(function () {
    window.onhashchange = function () {
        SinglePage.LoadModal();
    };
    $("#MainModal").on("shown.bs.modal",
        function () {
            window.location.hash = "##";
            $('.persianDateInput').persianDatepicker({
                format: 'YYYY/MM/DD HH:mm',
                autoClose: true
            });
        });

    $(document).on("submit",
        'form[data-ajax="true"]',
        function (e) {
            e.preventDefault();
            var form = $(this);
            const method = form.attr("method").toLocaleLowerCase();
            const url = form.attr("action");
            var action = form.attr("data-action");

            if (method === "get") {
                const data = form.serializeArray();
                $.get(url,
                    data,
                    function (data) {
                        CallBackHandler(data, action, form);
                    });
            } else {
                var formData = new FormData(this);
                $.ajax({
                    url: url,
                    type: "post",
                    data: formData,
                    enctype: "multipart/form-data",
                    dataType: "json",
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        CallBackHandler(data, action, form);
                    },
                    error: function (data) {
                        alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
                    }
                });
            }
            return false;
        });
});

function CallBackHandler(data, action, form) {
    switch (action) {
        case "Message":
            alert(data.Message);
            break;
        case "Refresh":
            if (data.isSuccedded) {
                window.location.reload();
            } else {
                alert(data.message);
            }
            break;
        case "RefereshList":
            {
                hideModal();
                const refereshUrl = form.attr("data-refereshurl");
                const refereshDiv = form.attr("data-refereshdiv");
                get(refereshUrl, refereshDiv);
            }
            break;
        case "setValue":
            {
                const element = form.data("element");
                $(`#${element}`).html(data);
            }
            break;
        default:
    }
}

function get(url, refereshDiv) {
    const searchModel = window.location.search;
    $.get(url,
        searchModel,
        function (result) {
            $("#" + refereshDiv).html(result);
        });
}

function makeSlug(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(convertToSlug(value));
}

var convertToSlug = function (str) {
    var $slug = '';
    const trimmed = $.trim(str);
    $slug = trimmed.replace(/[^a-z0-9-آ-ی-]/gi, '-').replace(/-+/g, '-').replace(/^-|-$/g, '');
    return $slug.toLowerCase();
};

function checkSlugDuplication(url, dist) {
    const slug = $('#' + dist).val();
    const id = convertToSlug(slug);
    $.get({
        url: url + '/' + id,
        success: function (data) {
            if (data) {
                sendNotification('error', 'top right', "خطا", "اسلاگ نمی تواند تکراری باشد");
            }
        }
    });
}

function fillField(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(value);
}

$(document).on("click",
    'button[data-ajax="true"]',
    function () {
        const button = $(this);
        const form = button.data("request-form");
        const data = $(`#${form}`).serialize();
        let url = button.data("request-url");
        const method = button.data("request-method");
        const field = button.data("request-field-id");
        if (field !== undefined) {
            const fieldValue = $(`#${field}`).val();
            url = url + "/" + fieldValue;
        }
        if (button.data("request-confirm") == true) {
            if (confirm("آیا از انجام این عملیات اطمینان دارید؟")) {
                handleAjaxCall(method, url, data);
            }
        } else {
            handleAjaxCall(method, url, data);
        }
    });

function handleAjaxCall(method, url, data) {
    if (method === "post") {
        $.post(url,
            data,
            "application/json; charset=utf-8",
            "json",
            function (data) {

            }).fail(function (error) {
                alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
            });
    }
}

jQuery.validator.addMethod("maxFileSize",
    function (value, element, params) {
        var size = element.files[0].size;
        var maxSize = 1 * 1024 * 1024;
        if (size > maxSize)
            return false;
        else {
            return true;
        }
    });
jQuery.validator.unobtrusive.adapters.addBool("maxFileSize");

jQuery.validator.addMethod("validateDropdown",
    function validateDropdown() {
        //Get dropdownlist selected value
        var selectedval = $('#Dropdown').find(":selected").text;
        //Check if selected value is empty or not
        if (selectedval == "") {
            //$("#errorMsgSpan").text("Please select a year");
            return false;
        }
        else {
            //$("#errorMsgSpan").text(" ");
            return true;
        }
    });
jQuery.validator.unobtrusive.adapters.addBool("validateDropdown");


$(document).ready(function () {
    $('#submit').on('click', function () {
        var files = $('#fUpload').prop("files");
        var fdata = new FormData();
        for (var i = 0; i < files.length; i++) {
            fdata.append("files", files[i]);
        }
        if (files.length > 0) {
            $.ajax({
                type: "POST",
                url: "/Index?handler=Upload",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                data: fdata,
                contentType: false,
                processData: false,
                success: function (response) {
                    alert('File Uploaded Successfully.')
                }
            });
        }
        else {
            alert('Please select a file.')
        }
    })
});


//jQuery.validator.addMethod("fileExtentionLimitation",
//    function (value, element, params) {
//        var fileFormat = element.files[0].split('.').pop();
//        var validFormat = ["jpg", "jpeg", "png"];
//        var result = false;
//        var i;
//        for (i = 0; i < validFormat.length; i++) {
//            if (validFormat[i].toLowerCase() === fileFormat.toLowerCase()) {
//                result = true;
//                break;
//            }
//        }
//        debugger;
//        return result;
//    });
//jQuery.validator.unobtrusive.adapters.addBool("fileExtentionLimitation");

//if (fileFormat === inArray(validFormat))
//    return true;
//else {
//    return false;
//}
