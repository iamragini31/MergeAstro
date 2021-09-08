$(document).ready(function () {
    getAllLang();
    BindAddress();
});


function getAllLang() {
    debugger
    var lang = "<option value=0>Select</option>";
    $.ajax({
        url: "/PanditRegistration/GetSkill/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    lang += '<option value=' + data[i].LangID + '>' + data[i].lang + '</option>';

                }

                $('#PreferredLang').html(lang);
            }
        }

    });
}

function Subitform() {
    debugger
    var custid = $("#hdnsession").val();
    var hdnsession = $("#hdnsession").val();
    var txtfullname = $("#txtfullname").val();
    var ddlcountrycode = $("#ddlcountrycode").find("option:selected").text();
    var txtmobileno = $("#txtmobileno").val();
    var txtemail = $("#txtemail").val();
    var ddlgender = $("#ddlgender").find("option:selected").text();
    var ddlday = $("#ddlday").find("option:selected").val();
    var ddlmonth = $("#ddlmonth").find("option:selected").val();
    var ddlyear = $("#ddlyear").find("option:selected").text();
    var txttimeofbirth = $("#txttimeofbirth").val();
    var txtcity = $("#txtcity").val();
    var txtstate = $("#txtstate").val();
    var txtcountry = $("#txtCountry").val();
    var PreferredLang = $("#PreferredLang").find("option:selected").val();
    var Martial_Status = $("#Martial_Status").find("option:selected").text();
    var txttopicofcall = $("#txttopicofcall").val();
    var txtcityofbirth = $("#txtcityofbirth").val();
    var txtstateofbirth = $("#txtstateofbirth").val();
    var txtcountryofbirth = $("#txtcountryofbirth").val();
    var txtOccupation = $("#txtOccupation").val();
    var txtAddress = $("#txtAddress").val();
    var txtZip = $("#txtZip").val();
    var addressid = $("input:radio[name=radio]:checked").val()

    if (hdnsession == null || hdnsession == "" || hdnsession == undefined) {
        alert("Login or Sign up before Proceeding further");
    }
    else if (addressid == "" || addressid == undefined  && (txtAddress == "" || txtZip == "" || txtstate == "" || txtcountry == "")) {
        alert("Select or Enter your complete Address");
    }
    //else if (addressid == "" || addressid == undefined && (txtAddress == "")) {
    //    alert("Select or Enter your complete Address");
    //}
    //else if (addressid == "" || addressid == undefined  && (txtZip == "")) {
    //    alert("Select or Enter your complete Address");
    //}
    //else if (addressid == "" || addressid == undefined  && (txtcity == "")) {
    //    alert("Select or Enter your complete Address");
    //}
    //else if (addressid == "" || addressid == undefined  && (txtstate == "")) {
    //    alert("Select or Enter your complete Address");
    //}
    //else if (addressid == "" || addressid == undefined  && (txtcountry == "")) {
    //    alert("Select or Enter your complete Address");
    //}
    else if (txtfullname == "" || txtfullname == undefined ) {
        alert("Enter Your Full Name");
    }
    else if (ddlcountrycode == "Select" || ddlcountrycode == undefined) {
        alert("Select Country Code");
    }
    else if (txtmobileno == "" || txtmobileno == undefined) {
        alert("Enter Your Mobile Number");
    }
    else if (txtemail == "" || txtemail == undefined) {
        alert("Enter E-mail Address");
    }
    else if (ddlgender == "Select" || ddlgender == undefined) {
        alert("Select Your Gender");
    }
    else if (ddlday == "Select" || ddlday == undefined) {
        alert("Select Day in Date of Birth");
    }
    else if (ddlmonth == "Select" || ddlmonth == undefined) {
        alert("Select Month in Date of Birth");
    }
    else if (ddlyear == "Select" || ddlyear == undefined) {
        alert("Select Year in Date of Birth");
    }
    else if (txttimeofbirth == "" || txttimeofbirth == undefined) {
        alert("Enter Time of Birth");
    }
    //else if (txtcity == "" || txtcity == undefined) {
    //    alert("Enter your City");
    //}
    //else if (txtstate == "" || txtstate == undefined) {
    //    alert("Enter Your State");
    //}
    //else if (txtcountry == "" || txtcountry == undefined) {
    //    alert("Enter Your Country");
    //}
    else if (PreferredLang == "Select" || PreferredLang == undefined) {
        alert("Select Language");
    }
    else if (Martial_Status == "Select" || Martial_Status == undefined) {
        alert("Select Your Marital Status");
    }
    else if (txttopicofcall == "" || txttopicofcall == undefined) {
        alert("Enter Topic for Call/Chat");
    }
    else if (txtcityofbirth == "" || txtcityofbirth == undefined) {
        alert("Enter City of Birth");
    }
    else if (txtstateofbirth == "" || txtstateofbirth == undefined) {
        alert("Enter State of Birth");
    }
    else if (txtcountryofbirth == "" || txtcountryofbirth == undefined) {
        alert("Enter Country Of Birth");
    }
    else if (txtOccupation == "" || txtOccupation == undefined) {
        alert("Enter Your Occupation");
    }
    else {
        var CustomerDetails = {
            name: txtfullname,
            gender: ddlgender,
            Martial_Status: Martial_Status,
            day: ddlday,
            month: ddlmonth,
            year: ddlyear,
            TimeOfBirth: txttimeofbirth,

            txtcity: txtcity,
            State: txtstate,
            Country: txtcountry,
            txtZip: txtZip,
            txtAddress: txtAddress,
            CountryCode: ddlcountrycode,
            Mobile: txtmobileno,

            Email: txtemail,
            PreferredLang: PreferredLang,

            TopicforCall: txttopicofcall,
            txtcityofbirth: txtcityofbirth,
            txtstateofbirth: txtstateofbirth,
            txtcountryofbirth: txtcountryofbirth,
            txtOccupation: txtOccupation,
            addressid: addressid

        };

       
        var formdata = new FormData();
        for (var key in CustomerDetails) {
            formdata.append(key, CustomerDetails[key]);
        }

        $.ajax({
            url: "/CallIntakeForm/SaveChat_Call_Service",
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (response) {
              var service=  $("#hdnservice").val();
                if (response !== 0 && response > 0) {
                    //$scope.StudentRegID = response;
                    alert(" " + service+"  Successfully booked.");
                    //clearform();
                    window.location.href = "/StartChat/Index?CustId=" + custid +"&Service=Chat";
                    //$scope.goToTab(2);
                }
                else {

                    alert("" + service+"   not booked.");
                    window.location.href = "/DefaultHome/Default";
                    //clearform();
                }
            },
            error: function (err) {

            }
        });
    }
}

function BindAddress() {
    $.ajax({
        url: "/CallIntakeForm/Bindaddress/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            var lang = "";  
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    lang += "<tr>"
                        + " <td>"
                        + "  <div class='radio'>"
                        + "  <label><input type='radio' id='rdadd" + i + "' name='radio' value='" + data[i].Addressid + "'></label>"
                        + "  </div>"
                        + " </td>"
                        + " <td>" + data[i].completeaddress + "<input type='hidden' id='hdnaddid" + i + " value='" + data[i].Addressid + "'/></td>"

                        + "</tr>";

                }

                $('#mytable').append(lang);
            }
            else {
                lang += " <p>"
                    + "You dont have any saved address(s), <br />"
                    + " Add Address by clicking on add address."
                    + " </p >";
                $('#NoAddressPara').append(lang);


            }
        }

    });
}

function validateEmail() {
    debugger
    var email = $("#txtEmail").val();
    var regx = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;;
    if (regx.test(email)) {

    }
    else {
        alert("Please enter a valid email");
    }
}

