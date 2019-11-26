



function CheckboxFunc() {
    var checkbox = document.getElementById("myCheck");
    var dropdown = document.getElementById("followupSearch");

    if (checkbox.checked) {
        dropdown.style.display = "block";
        $("#myCheck").addClass("check-width");
    }
    else {
        dropdown.style.display = "none";
        $("#myCheck").removeClass("check-width");
    }
}



//$(document).ready(function() {
//    if ($("#myCheck").checked) {
//        $("#myCheck").addClass("small_button_width");
//    } else {
//        $("#myCheck").removeClass("small_button_width");
//    });