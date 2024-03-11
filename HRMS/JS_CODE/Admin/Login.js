//log in crenditial taken here and checked 
//if valid then open the dashboard 
//otherwise give error message accordingly

$('#login').click(function () {
 
    var username = $('#username').val().trim();
    var password = $('#password').val().trim();
    if (username == '') { alertify.alert('Please Enter User ID!'); return false; }
    if (password == '') { alertify.alert('Please Enter Password!'); return false;}

    //disable the submit button
    $("#login").val('Wait....');
    $("#login").attr("disabled", true);

     $.ajax({
        type: "POST",
         url: "/Admin/Login",
         data: "{name: '" + username + "',password: '" + password + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: 'JSON',
        beforeSend: function () {
            $.blockUI({ message: '<h1><img src="../images/busy.gif" /> Please Wait...</h1>' });
        }
    }).done(function (response) {
        debugger;
        if (response.success) {
            window.location = "/Admin/Dashboard";  
        }
        else {
            //enable the submit button
            $("#login").attr("disabled", false);
            $("#login").val('SIGN IN'); 
            alertify.alert('No Record Found!');
        }

    }).always(function () { $.unblockUI(); }).fail(function () { alert("Enter Valid UserID or PAssword"); });
     
});



