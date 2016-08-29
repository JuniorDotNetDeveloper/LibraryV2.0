$(function () {
    var createProductLinkSelector = "#createProductLink";
    var dlgCreateProductSelector = "#dlgCreateProduct";
    var createProductFormSelector = "#createProductForm";

    $(createProductLinkSelector).click(function () {
        $.get("http://localhost/Internship.Presentation.MVC/Products/CreateProduct",
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
                        "Create product": SaveCreateProductForm,
                        Cancel: function () {
                            popup.dialog("close");
                        }
                    }
                });

                popup.dialog('open');
            });
    });
});