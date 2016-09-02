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