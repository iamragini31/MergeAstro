function Login() {
    debugger
    var Username = $("#UserName").val();
    var password = $("#Password").val();
    var checkboxloginPandit = document.getElementById("checkboxloginPandit");

    if (Username == "" || Username == null || Username == undefined) {
        alert("Enter Username");

    }
    else if (checkboxloginPandit.checked == false) {
        alert("Agree to Terms & Condition.");
    }
    else if (password == "" || password == null || password == undefined) {
        alert("Enter Password");

    }
    else {

    $.ajax({
        type: "GET",
        url: "/Login/LoginUser/",
        data: { "Username": Username, "password": password },
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            if (data == "1") {
                window.location.href = "/RegisterForm/RegisterForm";
            }
            else if (data == "2") {
                window.location.href = "/DefaultAdminPandit/DefaultAdminPandit";
            }
            else {
                alert("Invalid Username & Password");
            }

        }
        });

    }
}