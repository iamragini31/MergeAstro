var totamt = 0;
$(document).ready(function () {
    GetAllPandits();
});

function GetAllPandits() {
    
    var Panlist = "<option value=0>Select</option>";
    $.ajax({
        url: "/Payment/GetAllPandits/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
           
            
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    Panlist += '<option value=' + data[i].PanditId + '>' + data[i].FullName + '</option>';

                }

                $('#SelectPandit').html(Panlist);
            }
        }

    });
}


function Submit() {
    debugger
    var FromDate = $("#TxtFromDate").val();
    var ToDate = $("#TxtToDate").val();
    var PanditId = $("#SelectPandit").find("option:selected").val();



    var isFormValid = true;
    var StudentSaveDetails = {
        FromDate: FromDate,
        ToDate: ToDate,
        PanditId: PanditId,
    };

    var formdata = new FormData();
    for (var key in StudentSaveDetails) {
        formdata.append(key, StudentSaveDetails[key]);
    }
    if (PanditId == 0) {
        alert("Please Select Pandit Name");
        return false;
    }
      else if (FromDate == "" || FromDate == undefined) {
        alert("Please Enter From Date.");
        return false;
    }
    else if (ToDate == "" || ToDate == undefined) {
        alert("Please Enter To Date");
        return false;
    }
  
    else {
        $("#tblcallchatpaid tbody").children().remove();
       
        $("#tblservicespaid tbody").children().remove()
        $("#tblservicesunpaid tbody").children().remove()
        $("#tblcallchatunpaid tbody").children().remove()
        $("#divpayment").hide();
        $.ajax({
            url: "/Payment/FetchPaymentforservices",
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (Res) {
                
                var datares = Res;
                var tabstring = "";



                for (var i = 0; i < datares.length; i++) {
                    $("#divpayment").show();
                    tabstring += " <tr>"
                        + "<td>O21321</td>"
                        + "  <td>" + datares[i].Servicename + "</td>"
                        + "      <td>" + datares[i].customername + "</td>"
                        + "      <td>" + datares[i].receiveddate + "</td>"
                        + "       <td>$" + datares[i].amount + "</td>"
                        + "       <td>Paid</td>"
                        + "     </tr>";

                    




                }
                $("#tblservicespaid tbody").append(tabstring);
            },
            error: function (err) {

            }
        });

        $.ajax({
            url: "/Payment/FetchunpaidPaymentforservices",
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (Res) {
                debugger
                var datares = Res;
                var tabstring = "";
                


                for (var i = 0; i < datares.length; i++) {
                    $("#divpayment").show();
                    tabstring += "<tr>"
                        + " <td><input onclick='Savepaymentservices(" + datares[i].Bookingid + "," + datares[i].amount + "," + i + "  )' type='checkbox' id='service" + i + "' class='checkthis'/></td>"
                        + "  <td>O21321</td>"
                        + "  <td>" + datares[i].Servicename + "</td>"
                        + "      <td>" + datares[i].customername + "</td>"
                        + "      <td>" + datares[i].receiveddate + "</td>"
                        + "       <td>$" + datares[i].amount + "</td>"
                        + "   <td>Pending</td>"
                        + "    </tr >";




                }
                $("#tblservicesunpaid tbody").append(tabstring);
            },
            error: function (err) {

            }
        });

        $.ajax({
            url: "/Payment/FetchunpaidPaymentforcallchat",
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (Res) {
                debugger
                var datares = Res;
                var tabstring = "";



                for (var i = 0; i < datares.length; i++) {

                    $("#divpayment").show();
                    tabstring += "<tr>"
                        + " <td><input onclick='Savepayment(" + datares[i].Bookingid + "," + datares[i].amount+ "," + i + " )' type='checkbox' id='chat" + i + "' class='checkthis'/></td>"
                        + "  <td>O21321</td>"
                        + "  <td>10 mins</td>"
                        + "      <td>" + datares[i].customername + "</td>"
                        + "  <td>" + datares[i].Servicename + "</td>"
                      
                        + "      <td>" + datares[i].receiveddate + "</td>"
                        + "       <td>$" + datares[i].amount + "</td>"
                        + " <td>Pending</td>"
                        + " </tr>";



                }
                $("#tblcallchatunpaid tbody").append(tabstring);
            },
            error: function (err) {

            }
        });

        $.ajax({
            url: "/Payment/FetchpaidPaymentforcallchat",
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (Res) {
                debugger
                var datares = Res;
                var tabstring = "";
              


                for (var i = 0; i < datares.length; i++) {

                    $("#divpayment").show();
                    tabstring += "<tr>"
                      
                        + "  <td>O21321</td>"
                        + "  <td>10 mins</td>"
                        + "      <td>" + datares[i].customername + "</td>"
                        + "  <td>" + datares[i].Servicename + "</td>"

                        + "      <td>" + datares[i].receiveddate + "</td>"
                        + "       <td>$" + datares[i].amount + "</td>"
                        + " <td>Pending</td>"
                        + " </tr>";



                }
                $("#tblcallchatpaid tbody").append(tabstring);
            },
            error: function (err) {

            }
        });
    }
}


function Savepayment(Bookingid, amount, i) {
    debugger
    checkid = $("#chat" + i).prop('checked');
    var id = Bookingid;
     
    if (checkid == true) {
        totamt = parseFloat(totamt) + parseFloat(amount);
        $("#lblamount").text(totamt);
        $.ajax({
            url: "/Payment/SavePayment/?ID=" + id + "",
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {



            }

        });
    }
    else {
        $.ajax({
            url: "/Payment/UpdatePayment/?ID=" + id + "",
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {



            }

        });
        if (totamt == 0) {

        }
        else {
            totamt = parseFloat(totamt) - parseFloat(amount);
            $("#lblamount").text(totamt);
        }
    }

   
}


function Savepaymentservices(Bookingid, amount, i) {
    checkid = $("#service" + i).prop('checked');
    var id = Bookingid;
    if (checkid == true) {
        totamt = parseFloat(totamt) + parseFloat(amount);
        $("#lblamount").text(totamt);
        $.ajax({
            url: "/Payment/SavePayment/?ID=" + id + "",
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {



            }

        });
    }
    else {
        $.ajax({
            url: "/Payment/UpdatePayment/?ID=" + id + "",
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {



            }

        });
        if (totamt == 0) {

        }
        else {
            totamt = parseFloat(totamt) - parseFloat(amount);
            $("#lblamount").text(totamt);
        }
    }


}


function Payment() {
    if (totamt > 0) {
        alert('Payment Successfull');
        window.location.href = "/Payment/AdminPayment";
    }
    else {
        alert('Please Select any option to Proceed further')
    }
}