var mainUrl = window.location.origin;
var userCred = document.getElementById("userCred");
function RegisterJs() {
    var regform = document.getElementById("registerForm");
    const formData = new FormData(regform);
    userCred.style.display = "block";
    console.log("registerjs " + isRegClc);
    //$.ajax({
    //    type: "POST",
    //    url: 'Home/SendRegister',
    //    data: formData,
    //});
    return true;
}
function checkExists(element) {
    if (typeof (element) != 'undefined' && element != null) {
        console.log("Exists.");
    } else {
        console.log("doesnt exists");
    }
}