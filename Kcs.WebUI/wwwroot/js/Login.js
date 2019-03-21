$(document).ready(function () {
    $("input[type=checkbox]").change(function () {
        if ($(this).prop("checked")) {
            $(this).val(true);
        } else {
            $(this).val(false);
        }
    });

    $("#btnLogin").click(function (e) {

        e.preventDefault();

        var loginModel = new Object();
        loginModel.Email = $('#email').val();
        loginModel.Password = $('#password').val();
        loginModel.RememberMe = $('#rememberMe').val();

        $.ajax({
            url: '/Login/Index',
            type: 'POST',
            dataType: 'json',
            async: false,
            data: loginModel,
            success: function (response) {
                if (response.processStatus) {
                    window.location = '/Person/Index';
                }
                else {
                    alert(response.message);
                }
            },
            error: function (response) {
                alert(response.message);
            }
        });
    });
});


