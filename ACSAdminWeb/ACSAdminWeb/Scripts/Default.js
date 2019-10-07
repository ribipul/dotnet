$(document).ready(function () {
    $(".dtp").datepicker($.datepicker.regional["de"]).datepicker("option", {
        dateFormat: "mm/dd/yy",
        changeMonth: true,
        changeYear: true
    });
});

function cleanUp(st) {
    return st.replace("'", "''");
}