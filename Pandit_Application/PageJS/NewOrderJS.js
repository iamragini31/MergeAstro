var roomName; var room; var token; var CustID; var charges_call_per_minu; var Customerwalletamount; var Bookingid; var Mobile;
$(document).ready(function () {
    BindServices();
    Bindorderaccepted();
    BindCompleted();
    BindChat();
    BindCalls();
})

function BindServices() {
    $.ajax({
        type: "GET",
        url: "/Orders/BindServices/",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data !== null) {
                //if ($.fn.dataTable.isDataTable('#tblservice')) { $('#tblservice').DataTable().clear().destroy(); }
                debugger
                var rows = "";
                $.each(data, function (i, item) {
                    debugger
                    rows += "<tr> <td><a href='#' style='text-decoration:underline'>" + item.OrderID + "</a></td >"
                        + "  <td>" + item.Custname + "</td>"
                        + "   <td>" + item.ReceivedDate + "</td>"
                        + "   <td>" + item.Receivedtime+"</td>"
                        + " <td>" + item.Servicename + "</td > "
                        + "<td> <a href='#' class='btn btn-success' onclick='Acceptorder(" + item.ID + ")'> <span>Accept</span></a> <a href='#' class='btn btn-danger' onclick='Rejectorder(" + item.ID + ")'> <span>Reject</span></a></td> </tr>";
                        



                });
                $("#tblneworder tbody").append(rows);
                //$('#tblneworder').DataTable({
                //    'paging': true,
                //    'lengthChange': false,
                //    'searching': true,
                //    'ordering': true,
                //    'info': true,
                //    'autoWidth': false
                //})
            }
        }
    });
}

function Acceptorder(id) {
    $.ajax({
        type: "GET",
        url: "/Orders/Updateservice/?orderid=" + id + "",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data > 0) {
                alert("Order Accepted");
                window.location.href = " /OrderAccepted/OrderAccepted";
            }
            else {
                alert("Error Occured");
            }
               
            }
        
    });
   
}
function Rejectorder(id) {

    $.ajax({
        type: "GET",
        url: "/Orders/RejectService/?orderid=" + id + "",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data > 0) {
                alert("Order Rejected");
                window.location.href = "/RegectedOrders/RegectedOrders";
            }
            else {
                alert("Error Occured");
            }

        }

    });
  
}



function Bindorderaccepted() {
    $.ajax({
        type: "GET",
        url: "/OrderAccepted/BindServices/",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data !== null) {
                //if ($.fn.dataTable.isDataTable('#tblservice')) { $('#tblservice').DataTable().clear().destroy(); }
                debugger
                var rows = "";
                $.each(data, function (i, item) {
                    debugger
                    rows += "<tr> <td><a href='#' style='text-decoration:underline'>" + item.OrderID + "</a></td >"
                        + "  <td>" + item.Custname + "</td>"
                        + "   <td>" + item.ReceivedDate + "</td>"
                        + "   <td>3pm</td>"
                        + " <td>" + item.Servicename + "</td > "
                        + "<td><span class='badge' style='background-color:#ffb822;'>Pending</span><a href='#'  class='btn btn-danger' onclick='Complete(" + item.ID + ")'><span>Change to Complete</span></a ></td></tr>";




                });
                $("#tblacceptedorder tbody").append(rows);
                //$('#tblneworder').DataTable({
                //    'paging': true,
                //    'lengthChange': false,
                //    'searching': true,
                //    'ordering': true,
                //    'info': true,
                //    'autoWidth': false
                //})
            }
        }
    });
}



function Complete(id) {
    $.ajax({
        type: "GET",
        url: "/OrderAccepted/Complete/?orderid=" + id + "",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data > 0) {
                alert("Order Completed");
                window.location.href = "/CompletedOrders/CompletedOrders";
            }
            else {
                alert("Error Occured");
            }

        }

    });

}


function BindCompleted() {
    $.ajax({
        type: "GET",
        url: "/CompletedOrders/BindServices/",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data !== null) {
                //if ($.fn.dataTable.isDataTable('#tblservice')) { $('#tblservice').DataTable().clear().destroy(); }
                debugger
                var rows = "";
                $.each(data, function (i, item) {
                    debugger
                    rows += "<tr> <td><a href='#' style='text-decoration:underline'>" + item.OrderID + "</a></td >"
                        + "  <td>" + item.Custname + "</td>"
                        + "   <td>" + item.ReceivedDate + "</td>"
                        + "   <td>3pm</td>"
                        + " <td>" + item.Servicename + "</td > "
                        + "<td><span class='badge' style='background-color:#0abb87; '>Completed</span></td></tr>";




                });
                $("#tblordercomplete tbody").append(rows);
                //$('#tblneworder').DataTable({
                //    'paging': true,
                //    'lengthChange': false,
                //    'searching': true,
                //    'ordering': true,
                //    'info': true,
                //    'autoWidth': false
                //})
            }
        }
    });
}


function BindChat() {
    $.ajax({
        type: "GET",
        url: "/ChatOrders/BindChat/",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data !== null) {
                //if ($.fn.dataTable.isDataTable('#tblservice')) { $('#tblservice').DataTable().clear().destroy(); }
                debugger
                var rows = "";
                $.each(data, function (i, item) {
                    debugger
                    rows += "<tr> <td><a href='#' style='text-decoration:underline'>C44545</a></td >"
                        + "   <td>" + item.FirstName_Call + "</td>"
                        + "   <td>" + item.Gender + "</td>"
                        + "   <td>" + item.DOB + "</td > "
                        + "   <td>" + item.Time_of_Birth + "</td > "
                        + "   <td>" + item.City + "</td > "
                        + "   <td>" + item.State + "</td > "
                        + "   <td>" + item.Country + "</td > "
                        + "   <td>" + item.Martial_Status + "</td > "
                        + "   <td>" + item.Topicforcall + "</td > "
                        + "   <td>" + item.Language + "</td > "
                        //+ "   <td>" + item.Service + "</td > "
                        + "   <td> <button type='button' id='chatModalbtn' data-custid= '" + item.CustID +"' class='btn btn-success' data-toggle='modal' data-target='chatModal'> <span>Chat</span></button>  </td > "


                        //+ "<td> <a href='#' class='btn btn-success' onclick='Acceptorder(" + item.ID + ")'> <span>Accept</span></a> <a href='#' class='btn btn-danger' onclick='Rejectorder(" + item.ID + ")'> <span>Reject</span></a></td> </tr>";

                });
                $("#tblChatOrders tbody").append(rows);
               
            }
        }
    });
}


function BindCalls() {
    $.ajax({
        type: "GET",
        url: "/CallOrders/BindCalls/",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data !== null) {
                //if ($.fn.dataTable.isDataTable('#tblservice')) { $('#tblservice').DataTable().clear().destroy(); }
                debugger
                var rows = "";
                $.each(data, function (i, item) {
                    debugger
                    rows += "<tr> <td><a href='#' style='text-decoration:underline'>C44545</a></td >"
                        + "   <td>" + item.FirstName_Call + "</td>"
                        + "   <td>" + item.Gender + "</td>"
                        + "   <td>" + item.DOB + "</td > "
                        + "   <td>" + item.Time_of_Birth + "</td > "
                        + "   <td>" + item.City + "</td > "
                        + "   <td>" + item.State + "</td > "
                        + "   <td>" + item.Country + "</td > "
                        + "   <td>" + item.Martial_Status + "</td > "
                        + "   <td>" + item.Topicforcall + "</td > "
                        + "   <td>" + item.Language + "</td > "
                        //+ "   <td>" + item.Service + "</td > "
                        + "   <td> <a href='#' onclick='getroom(" + JSON.stringify(item) + ")' class='btn btn-success' data-toggle='modal'> <span>Call</span></a>  </td > "


                    //+ "<td> <a href='#' class='btn btn-success' onclick='Acceptorder(" + item.ID + ")'> <span>Accept</span></a> <a href='#' class='btn btn-danger' onclick='Rejectorder(" + item.ID + ")'> <span>Reject</span></a></td> </tr>";

                });
                $("#tblCallOrders tbody").append(rows);

            }
        }
    });
}

function getroom(item) {
    $.ajax({
        type: "POST",
        url: '/CallOrders/CreateRoom/',
        data: '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            debugger
            //var response = JSON.parse(r);
            roomName = r /*response.room.room_id*/;
          
            CustID = item.CustID;
            charges_call_per_minu = item.charges_call_per_minu;
            Customerwalletamount = item.Customerwalletamount;
            Bookingid = item.ID;
            Mobile = item.Mobile;
            Joinroom(item.FirstName_Call);
        },
        failure: function (response) {

            alert(response.d);
        }
    });
}
function Joinroom(name) {
    $.ajax({
        type: "GET",
        url: "/CallOrders/GetRoom/",
        data: {
            "roomId": roomName, "CustID": CustID, "charges_call_per_minu": charges_call_per_minu, "Customerwalletamount": Customerwalletamount, "Bookingid": Bookingid, "Mobile": Mobile},
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            var response = JSON.parse(data);
            room = response.room;

            room_id = room.room_id;
            var user_ref = name/*document.getElementById('nameText').value*/;
            var role = "moderator" /*document.getElementById('attendeeRole').value*/;
            var retData = {
                name: user_ref,
                role: role,
                roomId: room_id,
                user_ref: user_ref,
            };
            debugger
            var dat = JSON.stringify(retData);
            $.ajax({
                type: "POST",
                url: '/CallOrders/CreateToken/?details=' + dat + '',
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    debugger
                    var response = JSON.parse(r);
                    token = response.token;
                    window.location.href = "/CallCustomer/CallCustomer?token=" + token;



                },
                failure: function (response) {

                    alert(response.r);
                }
            });
        }
    });
}