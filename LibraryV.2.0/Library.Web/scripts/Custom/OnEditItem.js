
function EditItem(obj) {
    var currentBook = obj;
    $.ajax({
        url: "http://localhost/Library.Web/Book/Edit",
        type: "get", //send it through get method
        data: { id: $(currentBook).attr("itemid") },
        success: function (response) {
            editdialogPopup(response)
        },

        error: function (xhr) {
            //Do Something to handle error
        }
    });
}

function editdialogPopup(data) {
    var popup = $("#dlgEditBook");
    popup.html(data);

    popup.dialog(
    {
        title: "Edit Product",
        autoOpen: false,
        modal: true,    
        width: 500,
        buttons: {
            "Edit": Edit,
            Cancel: function () {
                popup.dialog("close");
            }
        }
    });
    popup.dialog('open');
    CallDatePicker();
}

function Edit() {
    var id = $("#editBookForm");

    $.ajax({
        url: "http://localhost/Library.Web/Book/Edit",
        type: "post", //send it through get method
        data: id.serialize(),
        success: function (response) {
            location.reload()
        },
        error: function (xhr) {
            //Do Something to handle error
        }
    });
}
