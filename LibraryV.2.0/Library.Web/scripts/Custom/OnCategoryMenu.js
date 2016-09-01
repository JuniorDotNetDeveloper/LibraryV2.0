function booksByCategory(obj) {
    var bookList = "#bookList";
    var categoryMenuSelector = obj;
    $.ajax({

        url: "http://localhost/Library.Web/Home/ConcreteCategory/",
        type: "get", //send it through get method
        data: { category: $(categoryMenuSelector).html() },
        success: function (response) {
            $(bookList).html(response)
        },
        error: function (xhr) {
            //Do Something to handle error
        }
    });
}

    //$(function () {
    //    var categoryMenuSelector = this;
    //    debugger;
    //    var bookList = "#bookList";
    

    //    //$.ajax({
    //    //    url: "http://localhost/Library.Web/Home/ConcreteCategory/",
    //    //    type: "get", //send it through get method
    //    //    data: { categoryName: $(categoryMenuSelector).text() },
    //    //    success: function (response) {
    //    //        //Do Something
    //    //    },
    //    //    error: function (xhr) {
    //    //        //Do Something to handle error
    //    //    }
    //    //});

    

    //    $(categoryMenuSelector).click(function () {
    //        $.ajax({
            
    //            url: "http://localhost/Library.Web/Home/ConcreteCategory/",
    //            type: "get", //send it through get method
    //            data: { category: $(categoryMenuSelector).html() },
    //            success: function (response) {
    //                $(bookList).html(response)
    //            },
    //            error: function (xhr) {
    //                //Do Something to handle error
    //            }
    //        });
    //        //$.get("http://localhost/Library.Web/Home/ConcreteCategory/" + $(categoryMenuSelector).text(),
    //        //    function (data) {
    //        //        debugger;
    //        //var popup = $(dlgCreateProductSelector);
    //        //popup.html(data);

    //        //popup.dialog(
    //        //{
    //        //    title: "Create Product",
    //        //    autoOpen: false,
    //        //    modal: true,
    //        //    width: 500,
    //        //    buttons: {
    //        //        "Create product": SaveCreateProductForm,
    //        //        Cancel: function () {
    //        //            popup.dialog("close");
    //        //        }
    //        //    }
    //        //});

    //        //popup.dialog('open');
    //        //});
    //    });
    //});