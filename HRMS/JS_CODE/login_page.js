$('#login').click(function () {
    debugger;
    var username = $('#username').val();
    var password = $('#password').val();
    if (username == '') { alert('Please select Username!'); return false }
    if (password == '') { alert('Please enter password!'); return false }

    //disable the submit button
    $("#login").val('Wait....');
    $("#login").attr("disabled", true);

    $.ajax({
        type: "POST",
        url: "/Login/Employee_login",
        data: "{Emp_Code: '" + username + "',Emp_Password: '" + password + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: 'JSON',
        beforeSend: function () {

        }
    }).done(function (response) {

        if (response.success) {
            //alert("seccessfully login");
            window.location = "../Home/Profile1";
        }
        else {

            $("#login").attr("disabled", false);
            $("#login").val('sign in');
            alert(response.responseText);
        }

    }).always(function () { $.unblockUI(); }).fail(function () {
        $("#login").val('Login');
        $("#login").attr("disabled", false);
        alert("Something went wrong. Please try again!");
    });


});





