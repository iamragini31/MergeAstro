$(document).ready(function () {
    debugger
    GetSpecialists();
    GetPuja();
    GetSpecialistsImagesWithName();
});

function GetSpecialists() {
    $.ajax({
        url: "/Specialists/GetSkill/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {
            debugger
            var datares = Res;
            var tabstring="";
            for (var i = 0; i < datares.length; i++) {

                tabstring += "         <li><a href='#' onclick='GetParticularSpecialists(" + datares[i].SpecialistID + ")'>" + datares[i].Sprcilistname+"</a ></li > "



            }
            $("#servicesdiv").append(tabstring);
        }

    });
}

function GetParticularSpecialists(id) {

}

function GetPuja() {
    $.ajax({
        url: "/Specialists/getAllPuja/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {
            var datares = Res;
            var tabstring = "";
            for (var i = 0; i < datares.length; i++) {

                tabstring += "         <li><a href='#' onclick='GetParticularPuja(" + datares[i].PujaID + ")'>" + datares[i].Pujaname + "</a ></li > "



            }
            $("#pujadiv").append(tabstring);
        }

    });
}

function GetParticularPuja(id) {
    $.ajax({
        type: "GET",
        url: "/Specialists/GetParticularPuja/",
        data: { "id": id },
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            debugger
            if (data == true) {
                $("#Msg").text('Data Updated Successfully!!'); $("#NotificationModal").modal({ show: true });
                $('#txtdocumentname').val(''); $('#txtDocumentDescription').val(''); BindDocument();
                $("#btnSubmitMeetingArea").show();
                $("#btnUpdateMeetingArea").hide();
            }
            else {
                $("#Msg").text('Data Not Updated'); $("#NotificationModal").modal({ show: true });
                $('#txtdocumentname').val(''); $('#txtDocumentDescription').val(''); BindMeetinArea();
                $("#btnSubmitMeetingArea").show();
                $("#btnUpdateMeetingArea").hide();
            }

        }
    });
}

function GetSpecialistsImagesWithName() {
    debugger
    $.ajax({
        url: "/Specialists/GetSpecialistsImagesWithName/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {
            debugger
            var datares = Res;
            var tabstring="";
            for (var i = 0; i < datares.length; i++) {

                //tabstring += "         <li><a href='#' onclick='GetParticularSpecialists(" + datares[i].SpecialistID + ")'>" + datares[i].Sprcilistname+"</a ></li > "

                tabstring += "<div class='col-lg-4 col-md-4 col-sm-6 col-xs-12'>"
                tabstring += " <div class='hs_shop_prodt_main_box'>"
                tabstring += "   <div class='   hs_shop_prodt_img_wrapper'>"
                tabstring += "<img src='/images/content/shop/" + datares[i].Images + "' alt='shop_product'>"
                tabstring += "<a href='#' onclick='Gotopunditlist(" + datares[i].SpecialistID +")'>View</a>"
                tabstring += "</div>"
                tabstring += " <div class='hs_shop_prodt_img_cont_wrapper'>"
                tabstring += " <h2><a href='#' onclick='Gotopunditlist(" + datares[i].SpecialistID +")'>" + datares[i].Specialization +"</a></h2>"
                tabstring += "</div>"
                tabstring += "</div>"
                tabstring += "</div>"

            }
            $("#SpecialistDetails").append(tabstring);
        }

    });
}

function Gotopunditlist(id) {
    window.location.href ="/PunditList/PunditList?ID="+id+""
}


