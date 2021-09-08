var file1;
$(document).ready(function () {

});

function Submit() {
    var txtSnum = $("#txtSnum").val();
    var PujaName = $("#txtPujaName").val();
    var Price = $("#txtPrice").val();
    var Description = $("#txtDescription").val();
   
    var isFormValid = true;
    var StudentSaveDetails = {
        txtSnum: txtSnum,
        PujaName: PujaName,
        Price: Price,
        Description: Description,
        files: file1,


    };

    var formdata = new FormData();
    for (var key in StudentSaveDetails) {
        formdata.append(key, StudentSaveDetails[key]);
    }

    if (txtSnum == "" || txtSnum == undefined)
    {
        alert("Please Enter Serial Number.");
        return false;
    }
    else if (PujaName == "" || PujaName == undefined)
    {
        alert("Please Enter Puja Name.");
        return false;
    }
    else if (Price == "" || Price == undefined)
    {
        alert("Please Enter Price.");
        return false;
    }
    else if (Description == "" || Description == undefined) {
        alert("Please Enter Description.");
        return false;
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
                    //clearform();
                   // window.location.href = "/DefaultHome/Default";
                    //$scope.goToTab(2);
                }
                else {

                    alert("Puja Not Saved Successfully.");
                   // window.location.href = "/DefaultHome/Default";
                    //clearform();
                }
            },
            error: function (err) {

            }
        });

    }
}