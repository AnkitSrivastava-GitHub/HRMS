


$(document).ready(function () {
    mandal();
    //GetURLParameter();

    candidate();
    $("#mandal").hide();
    $("#cand").hide();
    $("#dvnotice").hide();
    $("#cand").val() = '1000';
     
    $("#mandal").val() = '1000';

 
});
debugger;

$("#type").change(function () {
    var ctrl = $("#type").val();
    if (ctrl == '1') {
        $("#mandal").show();
        $("#cand").hide();
        $("#cand").val() = '1000';
        $("#dvnotice").hide();
    }
    else if (ctrl == '2') {
        $("#cand").show();
        $("#mandal").hide();
        $("#mandal").val() = '1000';
        $("#dvnotice").hide();
    }

    else {
       
        $("#mandal").hide();
        $("#cand").hide();
        $("#dvnotice").hide();
        alert("Select Notice for")
    }




});

$("#cand").change(function () {
    $("#dvnotice").show();

});
$("#mandal").change(function () {
    $("#dvnotice").show();
});



    function mandal(){
        var ctrl = $("#Janpad");
            ctrl.empty().append('<option selected="selected" value="" disabled="disabled">Loading.....</option>')
        $.ajax({
            type: "POST",
            url: "/Admin/Bind_Janpad",
            contentType: "application/json; charset=utf-8",
            dataType: 'JSON',
            beforeSend: function () {
                $.blockUI({ message: '<h1><img src="../images/busy.gif" /> </h1>' });
            }
        }).done(function (response) {

           /* ctrl.empty().append('<option selected="selected" value="">SELECT</option>');*/
            ctrl.empty().append('<option selected="selected" value="0">ALL</option>');

            $.each(response, function () {
             ctrl.append($("<option></option>").val(this["pk_id"]).html(this["Mandal_Name"]));
            });
        }).always(function () { $.unblockUI(); }).fail(function () { alert("Something went wrong. Please try again!"); });

     };

function candidate() {
    var ctrl = $("#candidate");
    ctrl.empty().append('<option selected="selected" value="" disabled="disabled"></option>')
    $.ajax({
        type: "POST",
        url: "/Admin/bind_candidate",
        contentType: "application/json; charset=utf-8",
        dataType: 'JSON',
        beforeSend: function () {
            $.blockUI({ message: '<h1><img src="../images/busy.gif" /> </h1>' });
        }
    }).done(function (response) {

      /*  ctrl.empty().append('<option selected="selected" value="">SELECT</option>');*/
        ctrl.empty().append('<option selected="selected" value="0">SELECT</option>');

        $.each(response, function () {

            ctrl.append($("<option></option>").val(this["pk_Emp_id"]).html(this["Emp_Code"]));
        });
    }).always(function () { $.unblockUI(); }).fail(function () { alert("Something went wrong. Please try again!"); });
}
