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