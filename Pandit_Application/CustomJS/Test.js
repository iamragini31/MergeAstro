var file1 = "";
$(document).ready(function () {



});

function DeletePoojaMaster(ID) {
    debugger
    debugger
    var checkstr = confirm('Are you sure you want to delete this?');
    if (checkstr == true) {
        $.ajax({
            url: "/PujaMaster/DeletebyId/",
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            data: { 'ID': ID },
            success: function (data) {
                debugger
                if (data == 1) {
                    alert("Data Deleted Succesfully");
                }
                else {
                    alert("Data Not Deleted");
                }

            }
        });
    } else {
        return false;
    }

}
function Submit() {
    debugger
    var txtSnum = $("#txtSnum").val();
    var PujaName = $("#txtPujaName").val();
    var Price = $("#txtPrice").val();
    var Description = $("#txtDescription").val();
    var ChangeStatus = $("#ddlChangeStatus").find("option:selected").val();

    var isFormValid = true;
    var StudentSaveDetails = {
        txtSnum: txtSnum,
        PujaName: PujaName,
        Price: Price,
        Description: Description,
        ChangeStatus: ChangeStatus,
        file1: file1
    };

    var fileUpload = $("#PujaImage").get(0);

    var filePath = fileUpload.value;


    var formdata = new FormData();
    for (var key in StudentSaveDetails) {
        formdata.append(key, StudentSaveDetails[key]);
    }

    if (txtSnum == "" || txtSnum == undefined) {
        alert("Please Enter Serial Number.");
        return false;
    }
    else if (PujaName == "" || PujaName == undefined) {
        alert("Please Enter Puja Name.");
        return false;
    }
    else if (Price == "" || Price == undefined) {
        alert("Please Enter Price.");
        return false;
    }
    else if (ChangeStatus == "Select") {
        alert("Please Change the Status.");
        return false;
    }
    else if (Description == "" || Description == undefined) {
        alert("Please Enter Description.");
        return false;
    }
    else if (filePath == "" || filePath == undefined) {
        alert("Please Choose Puja Image");
    }
    else {

        $.ajax({
            url: "/PujaMaster/SavePuja",
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (response) {

                if (response !== 0 && response > 0) {
                    //$scope.StudentRegID = response;
                    alert("Puja Saved Successfully");
                    
                    window.location.href = "/Pujamaster/AdminPujamaster";
                    //$scope.goToTab(2);
                }
                else {

                    alert("Puja Not Saved Successfully.");
                    window.location.href = "/Pujamaster/AdminPujamaster";
                   // clearform();
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
    var PujaName = $("#txtPujaName").val();
    var Price = $("#txtPrice").val();
    var Description = $("#txtDescription").val();
    var Id = $("#txtId").val();
    var ChangeStatus = $("#ddlChangeStatus").find("option:selected").val();


    var isFormValid = true;
    var StudentSaveDetails = {
        txtSnum: txtSnum,
        PujaName: PujaName,
        Price: Price,
        Description: Description,
        Id: Id,
        ChangeStatus: ChangeStatus,
        file1: file1
      
    };

    var fileUpload = $("#PujaImage").get(0);

    var filePath = fileUpload.value;


    var formdata = new FormData();
    for (var key in StudentSaveDetails) {
        formdata.append(key, StudentSaveDetails[key]);
    }

    if (txtSnum == "" || txtSnum == undefined) {
        alert("Please Enter Serial Number.");
        return false;
    }
    else if (PujaName == "" || PujaName == undefined) {
        alert("Please Enter Puja Name.");
        return false;
    }
    else if (Price == "" || Price == undefined) {
        alert("Please Enter Price.");
        return false;
    }
    else if (ChangeStatus == "Selected") {
        alert("Please Enter status.");
        return false;
    }
    else if (Description == "" || Description == undefined) {
        alert("Please Enter Description.");
        return false;
    }
    else if (filePath == "" || filePath == undefined) {
        alert("Please Choose Puja Image");
    }
    else {

        $.ajax({
            url: "/PujaMaster/UpdatePuja",
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (response) {

                if (response !== 0 && response > 0) {
                    //$scope.StudentRegID = response;
                    alert("Puja Data Updated Successfully");

                    window.location.href = "/Pujamaster/AdminPujamaster";
                    //$scope.goToTab(2);
                }
                else {

                    alert("Puja Not Updated Successfully.");
                    window.location.href = "/Pujamaster/AdminPujamasterr";
                    // clearform();
                }
            },
            error: function (err) {

            }
        });

    }
}
function SaveFile() {
    debugger

    var fileUpload = $("#PujaImage").get(0);

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
        url: "/PujaMaster/SaveFile",
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



function DisplayPujas() {

    $.ajax({
        url: "/PujaMaster/DisplayPujas/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {

            var datares = Res;
            var tabstring = "";



            for (var i = 0; i < datares.length; i++) {

                debugger
                 //var base64 = Convert.ToBase64String(Model.PujaImage);
                 //var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
               


                tabstring += "          <tr>"
                tabstring += "       <td>" + datares[i].Snum1 + "</td>"
                tabstring += "       <td>" + datares[i].Pujasname1 + " </td>"
                tabstring += "       <td>" + datares[i].Price1 + " </td>"
                //tabstring += "       <td>" <img src="@imgSrc"/> " </td>"
                tabstring += "       <td> <img src='data:image/png;base64," + datares[i].PujaImage +"' /></td>"

                tabstring += "       <td>" + datares[i].Description1 + " </td>"
                tabstring += " </tr>"




            }
            $("#PujaTable").append(tabstring);
        }

    });
}