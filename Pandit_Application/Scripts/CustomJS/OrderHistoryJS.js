
$(document).ready(function () {
    var custid = $("#hdnsession").val();
    if (custid == null || custid == "" || custid == undefined) {
        alert("Sign up or Login before Procedding further");
        window.location.href = "/DefaultHome/Default";
    }
    else {
        BindServices();
        BindCalldetails();
        BindChatdetails();
        BindPuja();
        BindReport();
    }
 
})

function BindPuja() {


    $.ajax({
        type: "GET",
        url: "/OrderHistory/Bindpuja/",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {

            if (data !== null) {
                //if ($.fn.dataTable.isDataTable('#tblservice')) { $('#tblservice').DataTable().clear().destroy(); }

                var rows = "";
                $.each(data, function (i, item) {
               
                    rows += "<tr>"
                    rows += "<td><p> " + item.Orderid + "</p> </td>"
                    rows += " <td>" + item.Servicename + "</td>"
                    rows += "<td>$" + item.Serviceprice + "</td>"
                    rows += "  <td>" + item.Received_Date + "</td> "
                    //rows += "  <td>12:30</td>"


                    rows += "    <td><span class='badge' style='background-color: #ffb822;'>" + item.Status + "</span></td></tr>";



                });
                $("#tblpuja tbody").append(rows);
                //$('#tblservice').DataTable({
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
function BindServices() {
   
   
        $.ajax({
            type: "GET",
            url: "/OrderHistory/BindServices/",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                
                if (data !== null) {
                    //if ($.fn.dataTable.isDataTable('#tblservice')) { $('#tblservice').DataTable().clear().destroy(); }
                    
                    var rows = "";
                    $.each(data, function (i, item) {
                        
                        rows += "<tr>"
                        rows += "<td><p>  " + item.Orderid + "</p> </td>"
                        rows += " <td>" + item.Servicename + "</td>"
                        rows += "<td>$" + item.Serviceprice + "</td>"
                        rows += "  <td>" + item.Received_Date + "</td> "
                        //rows += "  <td>12:30</td>"


                        rows += "    <td><span class='badge' style='background-color: #ffb822;'>" + item.Status + "</span></td></tr>";



                    });
                    $("#tblservice tbody").append(rows);
                    //$('#tblservice').DataTable({
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

function BindReport() {


    $.ajax({
        type: "GET",
        url: "/OrderHistory/BindReport/",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {

            if (data !== null) {
                //if ($.fn.dataTable.isDataTable('#tblservice')) { $('#tblservice').DataTable().clear().destroy(); }

                var rows = "";
                $.each(data, function (i, item) {

                    rows += "<tr>"
                    rows += "<td><p>  " + item.Orderid + "</p> </td>"
                    rows += " <td>" + item.Servicename + "</td>"
                    rows += "<td>$" + item.Serviceprice + "</td>"
                    rows += "  <td>" + item.Received_Date + "</td> "
                    //rows += "  <td>12:30</td>"


                    rows += "    <td><span class='badge' style='background-color: #ffb822;'>" + item.Status + "</span></td></tr>";



                });
                $("#tblReport tbody").append(rows);
                //$('#tblservice').DataTable({
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


function BindCalldetails() {
    debugger
   
   
        $.ajax({
            type: "GET",
            url: "/OrderHistory/BindCalldetails/",
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
                        rows += "<tr>"
                        rows += "<td><p>  " + item.Orderid + "</p> </td>"
                        rows += " <td>" + item.panditName + "</td>"
                        rows += "<td>$" + item.Callrate + "</td>"
                        rows += "  <td>" + item.Duration + "minutes</td> "
                        rows += "  <td>$0/minutes</td>"
                        rows += "  <td>" + item.Received_Date + "</td> "

                        rows += "</tr>";



                    });
                    $("#CallServeice tbody").append(rows);
                    //$('#CallServeice').DataTable({
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

function BindChatdetails() {
   
   
        $.ajax({
            type: "GET",
            url: "/OrderHistory/BindChatdetails/",
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
                        rows += "<tr>"
                        rows += "<td><p style='text-decoration:underline'>  " + item.Orderid + "</p> </td>"
                        rows += " <td>" + item.panditName + "</td>"
                        rows += "<td>$" + item.Callrate + "</td>"
                        rows += "  <td>" + item.Duration + "minutes</td> "
                        rows += "  <td>$20/minutes</td>"
                        rows += "  <td>" + item.Received_Date + "</td> "

                        rows += "</tr>";



                    });
                    $("#ChatService tbody").append(rows);
                    //$('#ChatService').DataTable({
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