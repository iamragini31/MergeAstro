$(document).ready(function () {
    BindPackages();
    BindPackagesForUpgrade();

});


function BindPackages() {
    $.ajax({
        url: "/Packages/BindPackages/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {

            var datares = Res;
            var tabstring = "";
            for (var i = 0; i < datares.length; i++) {
                debugger
                tabstring += "          <div class='col-lg-4 col-md-6 px-2 mb-4'>"
                tabstring += "     <div class='card text-center card__hover'>"
                tabstring += "      <div class='card-header'>"
                tabstring += "<input type='hidden' value='" + datares[i].packageID + "' id='hdnpackageid" + datares[i].packageID + "'/>"
                tabstring += "              <h3 class='display-4'><span class='currency'>$</span>" + datares[i].packageprice + ".00 <span class='period'>/Year</span></h3> "
                tabstring += "      </div>"
                tabstring += "        <div class='card-block'>"
                tabstring += "        <h4 class='card-title'>" + datares[i].PackageName + " </h4> "
                tabstring += "            <ul class='list-group'>"
                tabstring += "               <li class='list-group-item'>" + datares[i].packageDescription + "</li> "
                //<li class='list-group-item'>Taxes/GST as Applicable (As per Locations)</li>

                tabstring += "     </ul>"   
                tabstring += "        </div>"

                tabstring += "              </div>"
                tabstring += "        </div >"


            }
            $("#packages").append(tabstring);
        }

    });
}

function BindPackagesForUpgrade() {
    $.ajax({
        url: "/Packages/BindPackagesForUpgrade/",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (Res) {

            var datares = Res;
            var tabstring = "";
            for (var i = 0; i < datares.length; i++) {
                debugger
                tabstring += "          <div class='col-lg-4 col-md-6 px-2 mb-4'>"
                tabstring += "     <div class='card text-center card__hover'>"
                tabstring += "      <div class='card-header'>"
                tabstring += "<input type='hidden' value='" + datares[i].packageID + "' id='hdnpackageid" + datares[i].packageID + "'/>"
                tabstring += "              <h3 class='display-4'><span class='currency'>$</span>" + datares[i].packageprice + ".00 <span class='period'>/Year</span></h3> "
                tabstring += "      </div>"
                tabstring += "        <div class='card-block'>"
                tabstring += "        <h4 class='card-title'>" + datares[i].PackageName + " </h4> "
                tabstring += "            <ul class='list-group'>"
                tabstring += "               <li class='list-group-item'>" + datares[i].packageDescription + "</li> "
                //<li class='list-group-item'>Taxes/GST as Applicable (As per Locations)</li>

                tabstring += "     </ul>"
                tabstring += "   <input  style='margin-top:20px;' type='radio' id='package" + i + "' name='package' value='" + datares[i].packageID + "'><span>&nbsp;&nbsp;</span><label style='font-size: 21px;color: #ff7e00;'>Buy</label>"
                tabstring += "        </div>"

                tabstring += "              </div>"
                tabstring += "        </div >"


            }
            $("#packagesUpgrade").append(tabstring);
        }

    });
}