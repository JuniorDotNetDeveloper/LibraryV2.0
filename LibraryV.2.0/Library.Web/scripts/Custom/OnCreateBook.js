$(document).ready(function () {
    var createProductLinkSelector = "#createBookLink";
    var dlgCreateProductSelector = "#dlgCreateBook";
    var createProductFormSelector = "#createBookForm";
    


    $(createProductLinkSelector).click(function () {
        $.ajax({
            type: "GET",
            url: "http://localhost/Library.Web/Book/Create",
            success:  function (data) {
                var popup = $(dlgCreateProductSelector);
                popup.html(data);
                //AJAX request
                popup.dialog(
                {
                    title: "Create Product",
                    autoOpen: false,
                    modal: true,
                    width: 500,
                    buttons: {
                        "Create": SaveCreateProductForm,
                        Cancel: function () {
                            popup.dialog("close");
                        }
                    }
                });
                popup.dialog("open");
                CallDatePicker();
            },
            error: function (data) {
                alert(data)
            }
        });
    });

    function IsValidForm(formSelector, context) {
        ///<summary> Helper method that should be used for inline validation of forms.</summary>
        if ($.validator && $.validator.unobtrusive) {
            $(formSelector, context).removeData("validator");
            $(formSelector, context).removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse($(formSelector, context));
        }

        return $(formSelector, context).valid();
    }

    function SaveCreateProductForm() {
        var createProductForm = $(createProductFormSelector);
        if (IsValidForm(createProductForm)) {
            $.ajax({
                type: "POST",
                url: createProductForm.attr('action'),
                data: createProductForm.serialize(),
                success: function (data) {
                    location.reload();
                },
                 //function (data) {
                 //   debugger};
                
            });
        } else {
            return false;
        }
    }       
});