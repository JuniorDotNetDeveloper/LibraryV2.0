

function DeleteItem(obj) {
    var currentBook = obj;
    $.ajax({
        url: "http://localhost/Library.Web/Book/Delete",
        type: "get", //send it through get method
        data: { id: $(currentBook).attr("id") },
        success: function (response) {
            dialogPopup(response)
            debugger;
        },

        error: function (xhr) {
            //Do Something to handle error
        }
    });
}
        


function dialogPopup(data) {
    var popup = $("#dlgDeleteBook");
    popup.html(data);
        
    popup.dialog(
    {
        title: "Delete Product",
        autoOpen: false,
        modal: true,
        width: 500,
        buttons: {
            "Delete": Delete,
            Cancel: function () {
                popup.dialog("close");
            }
        }
    });
    popup.dialog('open');
    CallDatePicker();
}

function Delete() {
    var id = $("#bookId");
    debugger;

    $.ajax({
        url: "http://localhost/Library.Web/Book/Delete",
        type: "post", //send it through get method
        data: { id: id.attr("value") },
        success: function (response) {
            location.reload()
        },
        error: function (xhr) {
            //Do Something to handle error
        }
    });
}
