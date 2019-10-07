$(function () {
    var fDate;
    var tDate;

    $("#EDay1").attr('disabled', 'disabled');
    $("#EDay2").attr('disabled', 'disabled');
    $("#EDay3").attr('disabled', 'disabled');
    $("#EDay4").attr('disabled', 'disabled');

    $("#ADay1").attr('disabled', 'disabled');
    $("#ADay2").attr('disabled', 'disabled');
    $("#ADay3").attr('disabled', 'disabled');
    $("#ADay4").attr('disabled', 'disabled');

    $("#txtPurpose1").attr('disabled', 'disabled');
    $("#txtPurpose2").attr('disabled', 'disabled');
    $("#txtPurpose3").attr('disabled', 'disabled');
    $("#txtPurpose4").attr('disabled', 'disabled');
    $("#txtPurpose5").attr('disabled', 'disabled');
    
    //    ------------------------------------------------------------
    $("#EFrom1").change(function () {
        fDate = new Date($("#EFrom1").val());
        tDate = new Date($("#ETo1").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#EFrom1").val() != "" && $("#ETo1").val() != "") {
            $('#EDay1').val(days);
        }
        else {
            $('#EDay1').val("");
        }
    });

    $("#ETo1").change(function () {
        fDate = new Date($("#EFrom1").val());
        tDate = new Date($("#ETo1").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#EFrom1").val() != "" && $("#ETo1").val() != "") {
            $('#EDay1').val(days);
        }
        else {
            $('#EDay1').val("");
        }
    });
    //    ------------------------------------------------------------
    $("#EFrom2").change(function () {
        fDate = new Date($("#EFrom2").val());
        tDate = new Date($("#ETo2").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#EFrom2").val() != "" && $("#ETo2").val() != "") {
            $('#EDay2').val(days);
        }
        else {
            $('#EDay2').val("");
        }
    });

    $("#ETo2").change(function () {
        fDate = new Date($("#EFrom2").val());
        tDate = new Date($("#ETo2").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#EFrom2").val() != "" && $("#ETo2").val() != "") {
            $('#EDay2').val(days);
        }
        else {
            $('#EDay2').val("");
        }
    });
    //    ------------------------------------------------------------
    $("#EFrom3").change(function () {
        fDate = new Date($("#EFrom3").val());
        tDate = new Date($("#ETo3").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#EFrom3").val() != "" && $("#ETo3").val() != "") {
            $('#EDay3').val(days);
        }
        else {
            $('#EDay3').val("");
        }
    });

    $("#ETo3").change(function () {
        fDate = new Date($("#EFrom3").val());
        tDate = new Date($("#ETo3").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#EFrom3").val() != "" && $("#ETo3").val() != "") {
            $('#EDay3').val(days);
        }
        else {
            $('#EDay3').val("");
        }
    });
    //    ------------------------------------------------------------
    $("#EFrom4").change(function () {
        fDate = new Date($("#EFrom4").val());
        tDate = new Date($("#ETo4").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#EFrom4").val() != "" && $("#ETo4").val() != "") {
            $('#EDay4').val(days);
        }
        else {
            $('#EDay4').val("");
        }
    });

    $("#ETo4").change(function () {
        fDate = new Date($("#EFrom4").val());
        tDate = new Date($("#ETo4").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#EFrom4").val() != "" && $("#ETo4").val() != "") {
            $('#EDay4').val(days);
        }
        else {
            $('#EDay4').val("");
        }
    });
    //    ------------------------------------------------------------
    //    ------------------------------------------------------------
    $("#AFrom1").change(function () {
        fDate = new Date($("#AFrom1").val());
        tDate = new Date($("#ATo1").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#AFrom1").val() != "" && $("#ATo1").val() != "") {
            $('#ADay1').val(days);
        }
        else {
            $('#ADay1').val("");
        }
    });

    $("#ATo1").change(function () {
        fDate = new Date($("#AFrom1").val());
        tDate = new Date($("#ATo1").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#AFrom1").val() != "" && $("#ATo1").val() != "") {
            $('#ADay1').val(days);
        }
        else {
            $('#ADay1').val("");
        }
    });
    //    ------------------------------------------------------------
    $("#AFrom2").change(function () {
        fDate = new Date($("#AFrom2").val());
        tDate = new Date($("#ATo2").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#AFrom2").val() != "" && $("#ATo2").val() != "") {
            $('#ADay2').val(days);
        }
        else {
            $('#ADay2').val("");
        }
    });

    $("#ATo2").change(function () {
        fDate = new Date($("#AFrom2").val());
        tDate = new Date($("#ATo2").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#AFrom2").val() != "" && $("#ATo2").val() != "") {
            $('#ADay2').val(days);
        }
        else {
            $('#ADay2').val("");
        }
    });
    //    ------------------------------------------------------------
    $("#AFrom3").change(function () {
        fDate = new Date($("#AFrom3").val());
        tDate = new Date($("#ATo3").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#AFrom3").val() != "" && $("#ATo3").val() != "") {
            $('#ADay3').val(days);
        }
        else {
            $('#ADay3').val("");
        }
    });

    $("#ATo3").change(function () {
        fDate = new Date($("#AFrom3").val());
        tDate = new Date($("#ATo3").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#AFrom3").val() != "" && $("#ATo3").val() != "") {
            $('#ADay3').val(days);
        }
        else {
            $('#ADay3').val("");
        }
    });
    //    ------------------------------------------------------------
    $("#AFrom4").change(function () {
        fDate = new Date($("#AFrom4").val());
        tDate = new Date($("#ATo4").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#AFrom4").val() != "" && $("#ATo4").val() != "") {
            $('#ADay4').val(days);
        }
        else {
            $('#ADay4').val("");
        }
    });

    $("#ATo4").change(function () {
        fDate = new Date($("#AFrom4").val());
        tDate = new Date($("#ATo4").val());

        var diff = (tDate.getTime() - fDate.getTime());
        var day = 1000 * 60 * 60 * 24;

        var days = Math.round((diff / day)) + 1;
        if ($("#AFrom4").val() != "" && $("#ATo4").val() != "") {
            $('#ADay4').val(days);
        }
        else {
            $('#ADay4').val("");
        }
    });
    //    ------------------------------------------------------------
    //    ------------------------------------------------------------
    $("#chk1").change(function () {
        if (this.checked) {
            $("#txtPurpose1").attr('disabled', '');
        }
        else {
            $("#txtPurpose1").attr('disabled', 'disabled');
            $("#txtPurpose1").val("");
        }
    });

    $("#chk2").change(function () {
        if (this.checked) {
            $("#txtPurpose2").attr('disabled', '');
        }
        else {
            $("#txtPurpose2").attr('disabled', 'disabled');
            $("#txtPurpose2").val("");
        }
    });

    $("#chk3").change(function () {
        if (this.checked) {
            $("#txtPurpose3").attr('disabled', '');
        }
        else {
            $("#txtPurpose3").attr('disabled', 'disabled');
            $("#txtPurpose3").val("");
        }
    });

    $("#chk4").change(function () {
        if (this.checked) {
            $("#txtPurpose4").attr('disabled', '');
        }
        else {
            $("#txtPurpose4").attr('disabled', 'disabled');
            $("#txtPurpose4").val("");
        }
    });

    $("#chk5").change(function () {
        if (this.checked) {
            $("#txtPurpose5").attr('disabled', '');
        }
        else {
            $("#txtPurpose5").attr('disabled', 'disabled');
            $("#txtPurpose5").val("");
        }
    });
});