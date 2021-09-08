var english, hindi, french, german, bengali, spanish, urdu, tamil, language, Telugu, Marathi, Gujarati, Kannada, Malyalam, Odia, Assamese, Nepali, Punjabi, Sindhi;
var file1, file1filename, file1content;
var file2, file2filename, file2content;
var file3, file3filename, file3content;
var Palmistry, Kundli, Marriage_Specialist, Vastu, Puja, Business_Specialist, Career_Specialist, Spiritual_Healing_Specialist, Phychic_Reading_Specialist, Tarot, Vedic_Astrology,
    Gemology, KP_Astrology, Lal_Kitab_Astrology, Western_Astrology, Face_Reading, Signature_Reading, Vedic_Navgrah_Anusthan, Horary, specialist;
$(document).ready(function () {

    GetAllskill();
    GetAllSpecialization();
   


})
function GetAllskill() {
    $.ajax({
        url: "/PanditRegistration/GetSkill/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {

            var datares = Res;
            var tabstring = " <div class= 'col-sm-12 '>"
            tabstring += "    <div class='hs_kd_six_sec_input_wrapper'>"
            tabstring += "      <label>Languages You Speak (Choose atleast one)</label>"

            tabstring += "        </div>"
            tabstring += "       </div>"
            for (var i = 0; i < datares.length; i++) {

                tabstring += "    <div class='col-sm-3'>"

                tabstring += "      <div class='form-check'>"
                tabstring += "        <input class='form-check-input' type='checkbox' id='gridCheck" + i + " ' onclick='GetSkillDetails(" + i + ") '>"
                tabstring += "            <label id='lang" + i + "' class='form-check-label' for='gridCheck1'>" + datares[i].lang + "</label>"
                tabstring += "            </div>"
                tabstring += "       </div>"

            }
            $("#langdiv").append(tabstring);
        }

    });
}
function GetAllSpecialization() {
    $.ajax({
        url: "/PanditRegistration/GetSpecialization/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {

            var datares = Res;
            var tabstring = " <div class= 'col-sm-12 '>"
            tabstring += "    <div class='hs_kd_six_sec_input_wrapper'>"
            tabstring += "      <label>Services you provide (Choose atleast one)</label>"

            tabstring += "        </div>"
            tabstring += "       </div>"
            for (var i = 0; i < datares.length; i++) {

                tabstring += "    <div class='col-sm-3'>"

                tabstring += "      <div class='form-check'>"
                tabstring += "        <input class='form-check-input' type='checkbox' id='specilization" + i + " ' onclick='GetSpeciDetails(" + i + ") '>"
                tabstring += "            <label id='Specilist" + i + "' class='form-check-label' for='gridCheck1'>" + datares[i].Specialization + "</label>"
                tabstring += "            </div>"
                tabstring += "       </div>"

            }
            $("#specdiv").append(tabstring);
        }

    });
}
function GetSkillDetails(i) {

    var lang = $("#lang" + i).text();
    if (lang == 'English') {
        english = lang;
        language = lang;
    }
    if (lang == 'Hindi') {
        hindi = lang;
        language = lang;
    }
    if (lang == 'Bengali') {
        bengali = lang;
        language = lang;
    }
    if (lang == 'Tamil') {
        tamil = lang;
        language = lang;
    }
    if (lang == 'Spanish') {
        spanish = lang;
        language = lang;
    }
    if (lang == 'German') {
        german = lang;
        language = lang;
    }
    if (lang == 'Urdu') {
        urdu = lang;
        language = lang;
    }
    if (lang == 'French') {
        french = lang;
        language = lang;
    }
    //Added by mah
    if (lang == 'Telugu') {
        Telugu = lang;
        language = lang;
    }
    if (lang == 'Marathi') {
        Marathi = lang;
        language = lang;
    }
    if (lang == 'Gujarati') {
        Gujarati = lang;
        language = lang;
    }
    if (lang == 'Kannada') {
        Kannada = lang;
        language = lang;
    }
    if (lang == 'Malyalam') {
        Malyalam = lang;
        language = lang;
    }
    if (lang == 'Odia') {
        Odia = lang;
        language = lang;
    }
    if (lang == 'Assamese') {
        Assamese = lang;
        language = lang;
    }
    if (lang == 'Nepali') {
        Nepali = lang;
        language = lang;
    }
    if (lang == 'Punjabi') {
        Punjabi = lang;
        language = lang;
    }
    if (lang == 'Sindhi') {
        Sindhi = lang;
        language = lang;
    }


}
function GetSpeciDetails(i) {

    var Spec = $("#Specilist" + i).text();
    if (Spec == 'Palmistry') {
        Palmistry = Spec;
        specialist = Spec;
    }
    if (Spec == 'Kundli') {
        Kundli = Spec;
        specialist = Spec;
    }
    if (Spec == 'Marriage Specialist') {
        Marriage_Specialist = Spec;
        specialist = Spec;
    }
    if (Spec == 'Vastu') {
        Vastu = Spec;
        specialist = Spec;
    }
    if (Spec == 'Business Specialist') {
        Business_Specialist = Spec;
        specialist = Spec;
    }
    if (Spec == 'Career Specialist') {
        Career_Specialist = Spec;
        specialist = Spec;
    }
    if (Spec == 'Spiritual Healing Specialist') {
        Spiritual_Healing_Specialist = Spec;
        specialist = Spec;
    }
    if (Spec == 'Phychic Reading Specialist') {
        Phychic_Reading_Specialist = Spec;
        specialist = Spec;
    }
    if (Spec == 'Tarot') {
        Tarot = Spec;
        specialist = Spec;
    }
    if (Spec == 'Vedic_Astrology') {
        Vedic_Astrology = Spec;
        specialist = Spec;
    }
    if (Spec == 'Gemology') {
        Gemology = Spec;
        specialist = Spec;
    }
    if (Spec == 'KP_Astrology') {
        KP_Astrology = Spec;
        specialist = Spec;
    }
    if (Spec == 'Lal_Kitab_Astrology') {
        Lal_Kitab_Astrology = Spec;
        specialist = Spec;
    }
    if (Spec == 'Western_Astrology') {
        Western_Astrology = Spec;
        specialist = Spec
    }
    if (Spec == 'Face_Reading') {
        Face_Reading = Spec;
        specialist = Spec;
    }
    if (Spec == 'Signature_Reading') {
        Signature_Reading = Spec;
        specialist = Spec;
    }
    if (Spec == 'Vedic_Navgrah_Anusthan') {
        Vedic_Navgrah_Anusthan = Spec;
        specialist = Spec;
    }
    if (Spec == 'Horary') {
        Horary = Spec;
        specialist = Spec;
    }
}
function ValidateIt() {
    debugger
    return true;
}
function Submit() {

    debugger
    var Fullname = $("#txtfullname").val();
    var Mobile = $("#txtmobile").val();
    var countrycode = $("#ddlcountrycode").find("option:selected").text();
    var Email = $("#txtEmail").val();
    var gender = $("#ddlgender").find("option:selected").text();
    var Day = $("#ddlday").find("option:selected").val();
    var Month = $("#ddlmonth").find("option:selected").val();
    var year = $("#ddlyear").find("option:selected").text();
    var YearofExperience = $("#txtYearofExperience").val();
    var DailyActive = $("#DailyActive").val();
    var Address = $("#txtAddress").val();
    var City = $("#txtcity").val();
    var State = $("#txtstate").val();
    var Country = $("#txtCountry").val();
    var Zip = $("#txtZip").val();
    var aboutself = $("#txtaboutself").val();
    var isFormValid = true;
    var StudentSaveDetails = {
        Palmistry: Palmistry,
        Kundli: Kundli,
        Gemology: Gemology,
        Horary: Horary,
        Vedic_Navgrah_Anusthan: Vedic_Navgrah_Anusthan,
        Signature_Reading: Signature_Reading,
        Face_Reading: Face_Reading,
        KP_Astrology: KP_Astrology,
        Lal_Kitab_Astrology: Lal_Kitab_Astrology,
        Marriage_Specialist: Marriage_Specialist,
        Western_Astrology: Western_Astrology,
        Business_Specialist: Business_Specialist,
        Career_Specialist: Career_Specialist,
        Spiritual_Healing_Specialist: Spiritual_Healing_Specialist,
        Phychic_Reading_Specialist: Phychic_Reading_Specialist,
        Tarot: Tarot,
        Vastu: Vastu,
        Vedic_Astrology: Vedic_Astrology,
        Fullname: Fullname,
        Mobile: Mobile,
        countrycode: countrycode,
        Email: Email,
        gender: gender,
        Day: Day,
        Month: Month,
        year: year,
        YearofExperience: YearofExperience,
        DailyActive: DailyActive,
        Address: Address,
        City: City,
        State: State,
        Country: Country,
        Zip: Zip,
        aboutself: aboutself,
        english: english,
        hindi: hindi,
        french: french,
        german: german,
        bengali: bengali,
        spanish: spanish,
        urdu: urdu,
        tamil: tamil,
        Telugu: Telugu,
        Marathi: Marathi,
        Gujarati: Gujarati,
        Kannada: Kannada,
        Malyalam: Malyalam,
        Odia: Odia,
        Assamese: Assamese,
        Nepali: Nepali,
        Punjabi: Punjabi,
        Sindhi: Sindhi,
        files: file1,
        files1: file2,
        files2: file3,
        file1filename: file1filename,
        file2filename: file2filename,
        file3filename: file3filename,
        file1content: file1content,
        file2content: file2content,
        file3content: file3content,

    };
    var fileUpload = $("#profilepic").get(0);

    var filePath = fileUpload.value;


    var fileUpload1 = $("#idproof").get(0);
    var filePath1 = fileUpload1.value;

    var fileUpload2 = $("#biodata").get(0);
    var filePath2 = fileUpload2.value;
    var formdata = new FormData();

   
    for (var key in StudentSaveDetails) {
        formdata.append(key, StudentSaveDetails[key]);
    }
    debugger
    var email = document.getElementById("txtEmail").value;
    var chkemail ;
    $.ajax({
        url: "/PanditRegistration/Checkemail/",
        type: "GET",
        data: {
            'emailAddress': email
        },
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {
            debugger
            if (Res == false) {
                alert("Invalid Email")
                

            }
            else {
                if (Fullname == "" || Fullname == undefined) {
                    alert("Enter Full Name");
                    return false;
                }
                else if (countrycode == "Select") {
                    alert("Select Country Code")
                }
                else if (Mobile == "" || Mobile == undefined) {
                    alert("Enter Mobile");
                    return false;
                }

                //else if (Email == "" || Email == undefined) {
                //    alert("Enter Email");
                //    return false;
                //}
                else if (gender == "Select") {
                    alert("Select Gender");
                    return false;
                }
                else if (Day == "0") {
                    alert("Select Date of Birth");
                    return false;
                }
                else if (Month == "0") {
                    alert("Select Month of Birth");
                    return false;
                }
                else if (year == "Year") {
                    alert("Select Year of Birth");
                    return false;
                }
                else if (YearofExperience == "" || YearofExperience == undefined) {
                    alert("Enter Year of Experience");
                    return false;
                }
                else if (Address == "" || Address == undefined) {
                    alert("Enter Address");
                    return false;
                }
                else if (City == "" || City == undefined) {
                    alert("Enter City");
                    return false;
                }
                else if (State == "" || State == undefined) {
                    alert("Enter State");
                    return false;
                }
                else if (Country == "" || Country == undefined) {
                    alert("Enter Country");
                    return false;
                }
                else if (Zip == "" || Zip == undefined) {
                    alert("Enter Zip Code");
                    return false;
                }
                else if (language == "" || language == undefined || language == null) {
                    alert("Select Atleast One language");
                    return false;
                }
                else if (specialist == "" || specialist == undefined || specialist == null) {
                    alert("Select atleast One Specialization");
                    return false;
                }
                else if (filePath == "" || filePath == undefined) {
                    alert("Upload Profile Picture");
                }
                else if (filePath1 == "" || filePath1 == undefined) {
                    alert("Upload ID Proof");
                }
                //else if (filePath2 == "" || filePath2 == undefined) {
                //    alert("Choose Bio Data");
                //}
                else if (aboutself == "" || aboutself == undefined) {
                    alert("Write About Yourself");
                    return false;
                }

                else if (ValidateIt() == true) {
                    document.getElementById('oneclick').disabled = true;
                    document.getElementById("oneclick").style.backgroundColor = "#ffb568";
                    document.getElementById("oneclick").style.color = "white";
                }
                else {

                    $.ajax({
                        url: "/PanditRegistration/RegistrationPandit",
                        type: "POST",
                        contentType: false,
                        processData: false,
                        data: formdata,
                        success: function (response) {
                            debugger
                            if (response !== 0 && response > 0) {
                                //$scope.StudentRegID = response;
                                alert("Thank you for registering. We will get back to you within 3-5 days with further instructions.");
                                //clearform();
                                window.location.href = "/DefaultHome/Default";
                                //$scope.goToTab(2);
                            }
                            else if (response == 0) {
                                alert("This email id is already registered, log in");
                                window.location.href = "/DefaultHome/Default";
                            }
                            else {

                                alert("Error Occured");
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

    });
    



}
function checkFile() {



    var fileUpload = $("#profilepic").get(0);
    var files = fileUpload.files;
    var filePath = fileUpload.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png)$/i;
    if (!allowedExtensions.exec(filePath)) {
        alert("Upload file having extensions .jpeg/.jpg/.png only.");
        $("#profilepic").val('');
    }
}
function checkFile1() {
    var fileUpload = $("#idproof").get(0);
    var files = fileUpload.files;
    var filePath = fileUpload.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png)$/i;
    if (!allowedExtensions.exec(filePath)) {
        alert("Upload file having extensions .jpeg/.jpg/.png only.");
        $("#idproof").val('');
    }
}
function savefile1() {
    debugger
    var imgpath = document.getElementById('profilepic');
    if (!imgpath.value == "") {
        var img = imgpath.files[0].size;
        var imgsize = img / 1024;
        if (imgsize > 1024) {

            alert("Upload image size less then 1MB");
            document.getElementById('profilepic').value = []
        }
        else {
            var fileUpload = $("#profilepic").get(0);

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

            formdata.append('type', "profile");
            $.ajax({
                url: "/PanditRegistration/SaveFile",
                type: "POST",
                contentType: false,
                processData: false,
                data: formdata,
                success: function (response) {
                    debugger
                    file1 = response[0];
                    file1filename = response[1];
                    file1content = response[2];
                },
                error: function (err) {

                }
            });}

    }
}
function savefile2() {
    debugger
    var imgpath = document.getElementById('idproof');
    if (!imgpath.value == "") {
        var img = imgpath.files[0].size;
        var imgsize = img / 1024;
        if (imgsize > 1024) {

            alert("Upload image size less then 1MB");
            document.getElementById('idproof').value = []
        }
        else {
            var fileUpload = $("#idproof").get(0);

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

            formdata.append('type', "Govtid");
            $.ajax({
                url: "/PanditRegistration/SaveFile",
                type: "POST",
                contentType: false,
                processData: false,
                data: formdata,
                success: function (response) {
                    debugger

                    file2 = response[0];
                    file2filename = response[1];
                    file2content = response[2];
                },
                error: function (err) {

                }
            });
        }
        }
   
}
function savefile3() {
    debugger

    var fileUpload = $("#biodata").get(0);

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

    formdata.append('type', "biodata");
    $.ajax({
        url: "/PanditRegistration/SaveFile",
        type: "POST",
        contentType: false,
        processData: false,
        data: formdata,
        success: function (response) {
            debugger

            file3 = response[0];
            file3filename = response[1];
            file3content = response[2];
        },
        error: function (err) {

        }
    });
}

function validateEmail() {
    debugger
  
    var email = document.getElementById("txtEmail").value;

    //var expr = /^([\w-\.]+)@@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    //if (!expr.test(email)) {
    //    alert("Invalid email address.");
    //}
    //else {
        
    //}
    $.ajax({
        url: "/PanditRegistration/Checkemail/",
        type: "GET",
        data: {
            'emailAddress': email
        },
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {

            if (Res == false) {
                alert("Invalid Email")
    }
        }

    });
}
function Checknumber() {
    var mobile = $("#txtmobile").val();
    if (mobile.length < 10) {
        alert("Enter valid mobile number");
    }
}