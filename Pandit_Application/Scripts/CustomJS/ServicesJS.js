$(document).ready(function () {
    debugger
    GetServicesWithDetails();

});



function GetServicesWithDetails() {
    debugger
    $.ajax({
        url: "/Services/GetServicesWithDetails/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {
            debugger
            var datares = Res;
            var tabstring = "";
            for (var i = 0; i < datares.length; i++) {

                //tabstring += "         <li><a href='#' onclick='GetParticularSpecialists(" + datares[i].SpecialistID + ")'>" + datares[i].Sprcilistname+"</a ></li > "
                //tabstring += "<div class='row' style='border-top: 4px solid #ff7e00;'>"
                //tabstring += " <div class='col-lg-4'>"
                //tabstring += " <div class='hs_lest_news_img_wrapper' style='border:none'>"
                //tabstring += "<img src='/FilesImages/" + datares[i].Images + "' alt='blog_img'>"
                //tabstring += "</div>"
                //tabstring += "</div>"
                //tabstring += " <div class='col-lg-8'>"
                //tabstring += "<div class='hs_lest_news_cont_wrapper' style='border:none'>"
                //tabstring += "<h5>" + datares[i].Servicename + "</h5>"
                //tabstring += "<p style='padding-bottom:10px'>"
                //tabstring += "   <p style='padding-bottom:10px'> " + datares[i].Description + " </p >"
                //tabstring += "</div>"
                //tabstring += " <div class='hs_lest_news_cont_bottom' style=''>"
                //tabstring += "<div class='hs_lest_news_cont_bottom_left'>"
                //tabstring += "<p><a></a>1244 Booked</p>"
                //tabstring += "</div>"
                //tabstring += " <div class='hs_lest_news_cont_bottom_center'>"
                //tabstring += "  <p><a>Price: $" + datares[i].Price + "</a></p>"
                //tabstring += "</div>"
                //tabstring += "<div class='hs_lest_news_cont_bottom_right'>"
                //tabstring += "<p><a href='/SelectedPuja/SelectedPuja?ID=" + datares[i].ServiceID +"&Servicename=Services'>Book Now</a></p>"
                //tabstring += "</div>"
                //tabstring += "</div>"
                //tabstring += "</div>"
                //tabstring += "</div>"
                //tabstring += "  <br />"
                //tabstring += "  <br />"



                tabstring += "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 modal-contents find'>"
                tabstring += " <div class='row'>"
                tabstring += "   <div class='col-lg-4'>"
                tabstring += "   <div class='hs_lest_news_img_wrapper' style='border:none;'>"
                tabstring += "      <img src='/FilesImages/" + datares[i].Images + "' style='    border-radius: 6px;margin-bottom:10px' alt='blog_img'>"
                tabstring += "</div>"
                tabstring += "</div>"
                tabstring += " <div class='col-lg-8'>"
                tabstring += " <div class='hs_lest_news_cont_wrapper' style='border:none;padding-top: 0px;padding-left: 10px; padding-right: 20px;'>"
                tabstring += "<h5>" + datares[i].Servicename + "</h5>"
                tabstring += "   <p style='padding-bottom:15px'> " + datares[i].Description + " </p >"

                tabstring += "<div class='col-lg-2 col-md-2 hs_kd_six_sec_btn' style='float: left; width: 75px; margin-top: 6px;padding-left: 0px;'>"
                tabstring += "<ul style='display:inline'>"
                tabstring += " <li style='display:inline'><a  href='/SpecialistServices/SpecialistServices?ID=" + datares[i].ServiceID + "&Name=" + datares[i].Servicename + "&Type=Service'>Book Now</a> </li>"
                tabstring += "  </ul>"
                tabstring += "</div>"
                tabstring += "</div>"
                tabstring += "</div>"
                tabstring += "</div>"
                tabstring += "</div>"





                //tabstring += " <div class='hs_lest_news_cont_bottom' style=''>"
                //tabstring += "<div class='hs_lest_news_cont_bottom_left'>"
                //tabstring += "<p><a></a>1244 Booked</p>"
                //tabstring += "</div>"
                //tabstring += " <div class='hs_lest_news_cont_bottom_center'>"
                ////tabstring += "  <p><a></a>Price: $" + datares[i].Price + "</p>"
                //tabstring += "</div>"
                //tabstring += "<div class='hs_lest_news_cont_bottom_right'>"
                ////tabstring += "<p><a onclick='CheckLogin(" + datares[i].ServiceID + ",2)'>Book Now</a></p>"
                //tabstring += "<p><a  href='/SpecialistServices/SpecialistServices?ID=" + datares[i].ServiceID + "&Type=Service'>Book Now</a></p>"

                //tabstring += "</div>"
                //tabstring += "</div>"
                //tabstring += "</div>"
                //tabstring += "</div>"
                //tabstring += "</div>"
              

            }
            $("#GetServicesWithDetailsAndImages").append(tabstring);
        }

    });
}