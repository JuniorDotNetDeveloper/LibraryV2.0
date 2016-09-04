$(document).ready(function () {
    var createProductLinkSelector = "#createBookLink";
    var dlgCreateProductSelector = "#dlgCreateBook";
    var createProductFormSelector = "#createBookForm";
    


    $(createProductLinkSelector).click(function () {
        $.get("http://localhost/Library.Web/Book/Create",
            function (data) {
                var popup = $(dlgCreateProductSelector);
                popup.html(data);

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

                popup.dialog('open');
                CallDatePicker();
               
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

    function CallDatePicker() {
        $("#dateselection").datepicker({
            numberOfMonths: 1,
            showWeek: true,
            changeMonth: true,
            changeYear: true,
            showButtonPanel: false,
            minDate: new Date(2008, 1 - 1, 1),
            maxDate: new Date(2100, 12 - 1, 31)
        });
        $("#dateselection").datepicker("setDate", new Date());
    }

    function SaveCreateProductForm() {
        var createProductForm = $(createProductFormSelector);
        if (IsValidForm(createProductForm)) {
            $.ajax({
                type: "POST",
                url: createProductForm.attr('action'),
                data: createProductForm.serialize(),
                success: function (data) {
                    alert("saved");
                }
            });
        } else {
            return false;
        }
    }
});