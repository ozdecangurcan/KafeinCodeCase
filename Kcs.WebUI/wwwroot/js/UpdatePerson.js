$(document).ready(function () {
    $("#btnUpdate").click(function () {

        var personViewModel = new Object();
        personViewModel.PersonId = $("#personId").val();
        personViewModel.PersonName = $('#personName').val();
        personViewModel.PersonSurname = $('#personSurname').val();
        personViewModel.PersonEmail = $('#personMail').val();
        personViewModel.PersonPhone = $('#personPhone').val();
        personViewModel.PersonBirthday = $('#personBirthday').val();
        personViewModel.ProvinceId = $('#provienceDdl').val();
        personViewModel.DistrictId = $('#districtDdl').val();

            $.ajax({
                url: '/Person/UpdatePerson',
                type: 'POST',
                dataType: 'json',
                data: personViewModel,
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


