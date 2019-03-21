$(document).ready(function () {
    $("#btnReset").click(function (e) {

        e.preventDefault();

        var resetPasswordModel = new Object();
 
        resetPasswordModel.EMail = $('#personMail').val();
        resetPasswordModel.Password = $('#personPassword').val();

        $.ajax({
            url: '/Login/ResetPassword',
            type: 'POST',
            dataType: 'json',
            async: false,
            data: resetPasswordModel,
            success: function (response) {
                if (response.processStatus) {
                    alert(response.message);
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