$(document).ready(function () {
    $("#btnCreate").click(function (e) {

        e.preventDefault();

        var personCreateViewModel = new Object();
        personCreateViewModel.PersonName = $('#personName').val();
        personCreateViewModel.PersonSurname = $('#personSurname').val();
        personCreateViewModel.PersonEmail = $('#personMail').val();
        personCreateViewModel.PersonPhone = $('#personPhone').val();
        personCreateViewModel.PersonBirthday = $('#personBirthday').val();
        personCreateViewModel.Password = $('#personPassword').val();
        personCreateViewModel.ProvinceId = $('#provienceDdl').val();
        personCreateViewModel.DistrictId = $('#districtDdl').val();

        $.ajax({
            url: '/Person/CreateUser',
            type: 'POST',
            dataType: 'json',
            async: false,
            data: personCreateViewModel,
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

    var provienceID = $("#provienceDdl").val();
    if (provienceID != null && provienceID != '') {
        $.ajax({
            type: "post",
            url: '/District/GetDistrictList',
            data: { provienceId: provienceID },
            success: function (districts) {
                var districtDdl = $("#districtDdl");
                districtDdl.empty();
                $.each(districts, function (i, item) {
                    districtDdl.append($("<option></option>").attr("value", item.districtId).html(item.districtName));
                });
            }
        });
    }

    $('#provienceDdl').change(function () {
        var provienceID = $(this).val();
        if (provienceID != null && provienceID != '') {
            $.ajax({
                type: "post",
                url: '/District/GetDistrictList',
                data: { provienceId: provienceID },
                success: function (districts) {
                    var districtDdl = $("#districtDdl");
                    districtDdl.empty();
                    $.each(districts, function (i, item) {
                        districtDdl.append($("<option></option>").attr("value", item.districtId).html(item.districtName));
                    });
                }
            });
        }
    });

});