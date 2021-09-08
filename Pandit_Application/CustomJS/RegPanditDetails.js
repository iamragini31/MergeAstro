/*nst { type } = require("os");

*/

$(document).ready(function () {
    DisplayImage();
    DownloadGovId();
    displayServices();
    BindPujas();
    BindReports();
    CallChat();
});


function DisplayImage() {

    $.ajax({
        url: "/RegPanditDetails/DisplayImage/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (response) {
            debugger
            var datares = response;

            document.getElementById("ProfileImage").src = datares;
        },
        error: function (err) {

        }

    });}
function displayServices() {
    $.ajax({
        url: "/RegPanditDetails/BindServices",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (res) {
            if (res != null) {
                debugger
                $.each(res, function (i, item) {
                    debugger
                    var rows = "<tr>"
                        + "<td>" + item.Service_Snum + "</td>"
                        + "<td>" + item.Servicename + "</td>"
                        + "<td>" + item.ServicePriceUS + "</td>"
                        + "<td>" + item.ServicePriceINR + "</td>"
                        + "</tr>"

                    $("#tblServices tbody").append(rows);
                });                                
            }

        }
    });

}

function BindPujas() {
    $.ajax({
        url: "/RegPanditDetails/BindPujas",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (res) {
            if (res != null) {
                debugger
                $.each(res, function (i, item) {
                    debugger
                    var rows = "<tr>"
                        + "<td>" + item.Puja_Snum + "</td>"
                        + "<td>" + item.PujasName + "</td>"
                        + "<td>" + item.pujaPriceUs + "</td>"
                        + "<td>" + item.pujaPriceINR + "</td>"
                        + "</tr>"

                    $("#tblPujas tbody").append(rows);
                });
            }

        }
    });

}

function BindReports() {
    $.ajax({
        url: "/RegPanditDetails/BindReports",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (res) {
            if (res != null) {
                debugger
                $.each(res, function (i, item) {
                    debugger
                    var rows = "<tr>"
                        + "<td>" + item.Report_Snum + "</td>"
                        + "<td>" + item.ReportName + "</td>"
                        + "<td>" + item.ReportPriceUS + "</td>"
                        + "<td>" + item.ReportPriceINR + "</td>"
                        + "</tr>"

                    $("#tblreports tbody").append(rows);
                });
            }

        }
    });

}

function CallChat() {
    $.ajax({
        url: "/RegPanditDetails/CallChat",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (res) {
            if (res != null) {
                debugger
                $.each(res, function (i, item) {
                    debugger
                    var rows = "<tr>"
                        + "<td>" + item.Call_Rate_USD + "</td>"
                        + "<td>" + item.Call_Rate_INR + "</td>"
                        + "<td>" + item.Chat_Rate_USD + "</td>"
                        + "<td>" + item.Chat_Rate_INR + "</td>"
                        + "</tr>"

                    $("#CallChat tbody").append(rows);
                });
            }

        }
    });

}

function DownloadGovId() {
    $.ajax({
        url: "/RegPanditDetails/GovernmentId/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data !== null) {
                //if ($.fn.dataTable.isDataTable('#tblDocument')) { $('#tblDocument').DataTable().clear().destroy(); }
                debugger
                $.each(data, function (i, item) {
                    debugger
                    var rows = "<tr>"
                        + "<td>" + 1 + "</td>"
                        + "<td>" + item.GovernmentIdFileName + "</td>"
                        + "<td><a href='javascript:;' onclick='DownloadFile(" + item.ID + ")'><i class='fa fa-download' aria-hidden='true'></i></a></td></tr>"
                        + "<tr>"
                        + "<td>" + 2 + "</td>"
                        + "<td>" + item.BioDataFileName + "</td>"
                        + "<td><a href='javascript:;' onclick='DownloadFile1(" + item.ID + ")'><i class='fa fa-download' aria-hidden='true'></i></a></td></tr>"


                    $("#tblDocument tbody").append(rows);
                });
                //$('#tblDocument').DataTable({
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
function DownloadFile(fileId) {
    debugger
    $("#hfGovID").val(fileId);
    $("#btnDownloadGovId")[0].click();
};
function DownloadFile1(fileId1) {
    debugger
    $("#hfGovID1").val(fileId1);
    $("#btnDownloadGovId1")[0].click();
};