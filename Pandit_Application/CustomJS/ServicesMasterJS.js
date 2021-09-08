
var file1 = "";
$(document).ready(function () {


});

function Submit() {
    debugger
    var txtSnum = $("#txtSnum").val();
    var ServiceName = $("#txtServiceName").val();
    var Price = $("#txtPrice").val();
    var Description = $("#txtDescription").val();
    var ChangeStatus = $("#ddlChangeStatus").find("option:selected").val();


    var isFormValid = true;
    var StudentSaveDetails = {
        txtSnum: txtSnum,
        ServiceName: ServiceName,
        Price: Price,
        Description: Description,
        ChangeStatus: ChangeStatus,
        file1: file1


    };

    var fileUpload = $("#ServiceImage").get(0);

    var filePath = fileUpload.value;


    var formdata = new FormData();
    for (var key in StudentSaveDetails) {
        formdata.append(key, StudentSaveDetails[key]);
    }

    if (txtSnum == "" || txtSnum == undefined) {
        alert("Please Enter Serial Number.");
        return false;
    }
    else if (ServiceName == "" || ServiceName == undefined) {
        alert("Please Enter Puja Name.");
        return false;
    }
    else if (Price == "" || Price == undefined) {
        alert("Please Enter Price.");
        return false;
    }
    else if (Description == "" || Description == undefined) {
        alert("Please Enter Description.");
        return false;
    }

    else if (ChangeStatus == "Select") {
        alert("Please Change the Status.");
        return false;
    }

    else if (filePath == "" || filePath == undefined) {
        alert("Please Choose Puja Image");
    }
    else {

        $.ajax({
            url: "/ServicesMaster/SaveService",
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (response) {

                if (response !== 0 && response > 0) {
                    //$scope.StudentRegID = response;
                    alert("Service Saved Successfully");

                    window.location.href = "/ServicesMaster/ServicesMaster";

                }
                else {

                    alert("Service Not Saved Successfully.");
                    window.location.href = "/ServicesMaster/ServicesMaster";

                }
            },
            error: function (err) {

            }
        });

    }
}

function UpdateData() {
    debugger
    var txtSnum = $("#txtSnum").val();
    var ServiceName = $("#txtServiceName").val();
    //var Price = $("#txtPrice").val();
    var Price = 100;
    var Description = $("#txtDescription").val();
    var Id = $("#txtId").val();
    var ChangeStatus = $("#ddlChangeStatus").find("option:selected").val();

    var isFormValid = true;
    var StudentSaveDetails = {
        txtSnum: txtSnum,
        ServiceName: ServiceName,
        Price: Price,
        Description: Description,
        Id: Id,
        ChangeStatus: ChangeStatus,
    };

    var fileUpload = $("#ServiceImage").get(0);

    var filePath = fileUpload.value;


    var formdata = new FormData();
    for (var key in StudentSaveDetails) {
        formdata.append(key, StudentSaveDetails[key]);
    }

    if (txtSnum == "" || txtSnum == undefined) {
        alert("Please Enter Serial Number.");
        return false;
    }
    else if (ServiceName == "" || ServiceName == undefined) {
        alert("Please Enter Puja Name.");
        return false;
    }
    else if (Price == "" || Price == undefined) {
        alert("Please Enter Price.");
        return false;
    }
    else if (Description == "" || Description == undefined) {
        alert("Please Enter Description.");
        return false;
    }
    else if (ChangeStatus == "Selected") {
        alert("Please Enter status.");
        return false;
    }
    else if (filePath == "" || filePath == undefined) {
        alert("Please Choose Puja Image");
    }
    else {

        $.ajax({
            url: "/ServicesMaster/UpdateService",
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (response) {

                if (response !== 0 && response > 0) {
                    //$scope.StudentRegID = response;
                    alert("Service Updated Successfully");

                    window.location.href = "/ServicesMaster/ServicesMaster";

                }
                else {

                    alert("Service Not Updated .");
                    window.location.href = "/ServicesMaster/ServicesMaster";

                }
            },
            error: function (err) {

            }
        });

    }
}
function SaveFile() {


    var fileUpload = $("#ServiceImage").get(0);

    var filePath = fileUpload.value;
    var StudentSaveDetails = {
        Id: 1,
    };
    StudentSaveDetails.files = fileUpload.files;
    StudentSaveDetails.filePath = fileUpload.value;
    StudentSaveDetails.allowedExtensions = /(\.jpg|\.jpeg|\.png)$/i;
    var formdata = new FormData();
    for (var i = 0; i < StudentSaveDetails.files.length; i++) {
        formdata.append(StudentSaveDetails.files[i].name, StudentSaveDetails.files[i]);
    }


    $.ajax({
        url: "/ServicesMaster/SaveFile",
        type: "POST",
        contentType: false,
        processData: false,
        data: formdata,
        success: function (response) {

            file1 = response;
        },
        error: function (err) {

        }
    });
}

function DeleteServiceMaster(ID) {
    debugger
    debugger
    var checkstr = confirm('are you sure you want to delete this?');
    if (checkstr == true) {
        $.ajax({
            url: "/ServicesMaster/DeletebyId/",
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            data: { 'ID': ID },
            success: function (data) {
                debugger
                if (data == 1) {
                    alert("Data Deleted Succesfully");

                    window.location.href = "/ServicesMaster/ServicesMaster";

                }
                else {
                    alert("Data Not Deleted");

                    window.location.href = "/ServicesMaster/ServicesMaster";

                }

            }
        });
    } else {
        return false;
    }

}
