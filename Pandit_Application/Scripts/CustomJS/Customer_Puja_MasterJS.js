$(document).ready(function () {
    getAllLang();
    //    BindAddress();
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
function SaveCustomerPuja() {
    debugger
    var custid = $("#hdnsession").val();
    if (custid == null || custid == "" || custid == undefined) {
        alert("Sign up or Login before Procedding further");
    }
    else {


        var name = $("#txtname").val();
        var ddlgender = $("#ddlgender").find("option:selected").val();
        var ddlMartial_Status = $("#ddlMartial_Status").find("option:selected").val();
        var ddlday = $("#ddlday").find("option:selected").val();
        var ddlmonth = $("#ddlmonth").find("option:selected").val();
        var ddlyear = $("#ddlyear").find("option:selected").val();
        var txtTimeOfBirth = $("#txtTimeOfBirth").val();
        //var PlaceOfBirth = $("#PlaceOfBirth").val();
        var txtcityofbirth = $("#txtcityofbirth").val();
        var txtstateofbirth = $("#txtstateofbirth").val();
        var txtcountryofbirth = $("#txtcountryofbirth").val();



        var CountryCode = $("#CountryCode").find("option:selected").text();
        var txtMobile = $("#txtMobile").val();
        if (txtMobile == "") {
            txtMobile = 0;
        }
        var txtOccupation = $("#txtOccupation").val();
        var txtEmail = $("#txtEmail").val();
        //var PreferredLang = $("#PreferredLang").find("option:selected").val();
        var txtAddress = $("#txtAddress").val();
        var txtcity = $("#txtcity").val();
        var txtstate = $("#txtstate").val();
        var txtcountry = $("#txtCountry").val();
        var txtZip = $("#txtZip").val();


        var txtTopicforCall = $("#txtTopicforCall").val();
        var addressid = $("input:radio[name=radio]:checked").val()

        if (name == "" || name == undefined || name == null) {
            alert("Enter Name");
            return false;
        }
        //else if (addressid == "" || addressid == undefined && (txtAddress == "" || txtZip == "" || txtstate == "" || txtcountry == "")) {
        //    alert("Select or Enter your complete Address");
        //}
        else if (ddlgender == "Select") {
            alert("Select Gender");
            return false;
        }
        else if (ddlMartial_Status == "Select") {
            alert("Select Martial Status");
            return false;
        }
        else if (ddlday == "Select") {
            alert("Select Gender");
            return false;
        }
        else if (ddlmonth == 0) {
            alert("Select Month");
            return false;
        }
        else if (ddlyear == "Select") {
            alert("Select Gender");
            return false;
        }
        else if (txtTimeOfBirth == "" || txtTimeOfBirth == undefined || txtTimeOfBirth == null) {
            alert("Enter Time Of Birth");
            return false;
        }
        else if (txtcityofbirth == "" || txtcityofbirth == undefined || txtcityofbirth == null) {
            alert("Enter City of Birth");
            return false;
        }
        else if (txtstateofbirth == "" || txtstateofbirth == undefined || txtstateofbirth == null) {
            alert("Enter State of Birth");
            return false;
        }
        else if (txtcountryofbirth == "" || txtcountryofbirth == undefined || txtcountryofbirth == null) {
            alert("Enter Country of Birth");
            return false;
        }
        else if (CountryCode == "" || CountryCode == undefined || CountryCode == null) {
            alert("Select Country Code");
            return false;
        }
        else if (txtMobile == "" || txtMobile == undefined || txtMobile == null) {
            alert("Enter Mobile");
            return false;
        }
        else if (txtOccupation == "" || txtOccupation == undefined || txtOccupation == null) {
            alert("Enter Occupation");
            return false;
        }
        else if (txtEmail == "" || txtEmail == undefined || txtEmail == null) {
            alert("Enter Email");
            return false;
        }
        else if (txtAddress == "" || txtAddress == undefined) {
            alert("Enter Your Address");
        }
        else if (txtcity == "" || txtcity == undefined) {
            alert("Enter Your City");
        }
        else if (txtstate == "" || txtstate == undefined) {
            alert("Enter Your State");
        }
        else if (txtcountry == "" || txtcountry == undefined) {
            alert("Enter Your Country");
        }
        else if (txtZip == "" || txtZip == undefined) {
            alert("Enter Your Zip/Pin Code");
        }
        //else if (txtTopicforCall == "" || txtTopicforCall == undefined || txtTopicforCall == null) {
        //    alert("Enter notes to specialist");
        //    return false;
        //}



        else {
            var CustomerDetails = {
                name: name,
                gender: ddlgender,
                Martial_Status: ddlMartial_Status,
                day: ddlday,
                month: ddlmonth,
                year: ddlyear,


                TimeOfBirth: txtTimeOfBirth,
                txtcityofbirth: txtcityofbirth,
                txtstateofbirth: txtstateofbirth,
                txtcountryofbirth: txtcountryofbirth,

                CountryCode: CountryCode,
                Mobile: txtMobile,
                Occupation: txtOccupation,
                Email: txtEmail,
                //PreferredLang: PreferredLang,

                Address: txtAddress,
                txtcity: txtcity,
                State: txtstate,
                Country: txtcountry,
                txtZip: txtZip,

                TopicforCall: txtTopicforCall,
                addressid: addressid
            };
            var formdata = new FormData();
            for (var key in CustomerDetails) {
                formdata.append(key, CustomerDetails[key]);
            }
            $.ajax({
                url: "/SelectedPuja/InsertSelectedPuja",
                type: "POST",
                contentType: false,
                processData: false,
                data: formdata,
                success: function (response) {

                    if (response !== 0 && response > 0) {
                        window.location.href = "/WalletPayment/WalletPayment";

                        //$.ajax({
                        //    url: "/AddWalletMoney/RazorpayGenerateOrderid?amount=" + response + "",
                        //    type: "GET",
                        //    contentType: "application/json",
                        //    dataType: "json",
                        //    success: function (response) {
                        //        if (response != null || response != "") {

                        //            window.location.href = "/PrePayment/PrePayment"
                        //            //window.location.reload();
                        //        }
                        //        else {

                        //            alert("Error Occured");


                        //        }
                        //    },
                        //    error: function (err) {

                        //        alert("Error Occured");
                        //    }
                        //});

                        //alert(" Pooja  Successfully booked.");

                        //window.location.href = "/DefaultHome/Default";

                    }
                    else {

                        alert("Pooja  Successfully not booked.");
                        window.location.href = "/DefaultHome/Default";
                        //clearform();
                    }
                },
                error: function (err) {

                }
            });

        }

    }
}
function BindAddress() {
    $.ajax({
        url: "/SelectedPuja/Bindaddress/",
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