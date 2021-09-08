$(document).ready(function () {
  
    DisplayPuja();
    DisplayServices();
    PaymentOption();
});
function PaymentOption() {
    
    $.ajax({
        url: "/ProfilePage/PaymentOption/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {
            debugger
            var datares = Res;
            var tabstring = "";
            var check = "";
            for (var i = 0; i < datares.length; i++) {

                check = datares[i].Payment_Method;
                if(check == "BankTransfer")
                {
                    tabstring += " <p><span style='color: #ff7e00'>Bank Name: </span>" + datares[i].Bank_Name + "</p>"
                    tabstring += "<p><span style='color: #ff7e00'>Account Number: </span> " + datares[i].Account_Number + "</p>"
                    tabstring += "  <p><span style='color: #ff7e00'>Account Holder Name: </span> " + datares[i].Account_holder_name + "</p>"
                    tabstring += "                <p><span style='color: #ff7e00'>IFSC Code: </span>" + datares[i].Routing_Number + "</p>"
                }
                if (check == "ZelleTransfer")
                {
                    tabstring += " <p><span style='color: #ff7e00'>Zelle Phone Number: </span>" + datares[i].PhoneNumber + "</p>"
                    tabstring += "<p><span style='color: #ff7e00'>:Email Address: </span> " + datares[i].Email_address + "</p>"
                }
                if (check == "PaypalTransfer")
                {
                    tabstring += " <p><span style='color: #ff7e00'>Paypal Number: </span>" + datares[i].PaypalAccountnumber + "</p>"
                }
                if (check == "GooglePayTransfer")
                {
                    tabstring += " <p><span style='color: #ff7e00'>Google Pay UPI: </span>" + datares[i].Google_Pay_ID + "</p>"
                }
                $("#PaymentOptionDisplay").append(tabstring);
            }
           
        }

    });
}

function DisplayPuja() {
 
    $.ajax({
        url: "/ProfilePage/DisplayPuja/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {

            var datares = Res;
            var tabstring = "";



            for (var i = 0; i < datares.length; i++) {
             
             

                tabstring += "          <tr>"
                tabstring += "       <td>" + datares[i].Pujasname + "</td>"
                tabstring += "       <td> $"+datares[i].Price+" </td>"
                tabstring += " </tr>"

        


            }
            $("#TableForPujaSelected").append(tabstring);
        }

    });
}

function DisplayServices() {

    $.ajax({
        url: "/ProfilePage/DisplayServices/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {
         
            var datares = Res;
            var tabstring = "";


            
            for (var i = 0; i < datares.length; i++) {
                


                tabstring += "          <tr>"
                tabstring += "       <td>" + datares[i].servicename + "</td>"
                tabstring += "       <td> $" + datares[i].ServicePrice + " </td>"
                tabstring += " </tr>"




            }
            $("#TableForServicesSelected").append(tabstring);
        }

    });
}