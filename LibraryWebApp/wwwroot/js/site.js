var mainUrl = window.location.origin;
function RegisterJs(e) {
    console.log("here");
    var regform = document.getElementById("registerForm");
    var formData = new FormData(regform);
    var firstname = formData.get("firstname");
    var lastname = formData.get("lastname");
    var bool = false;
    $.ajax({
        type: "POST",
        url: 'Register',
        data: formData.values,
        async: false,
        success: function () {
            console.log("succes");
            //document.cookie = "firstname=" + firstname + "," + "lastname=" + lastname + ",page=0" + ";path=/";
            //window.location.replace(mainUrl);
            bool = true;
        },
        error: function () {
            bool = false;
            console.log("error");
        }
    });
    console.log("bool " + bool);
    return bool;
}
function userCred() {
    var str_array = document.cookie.split(',');
    if (str_array != null && str_array.length >1) {
        var page = str_array[2].replace('page=', '');
        if (page == 0 || page == "0") {
            var fname = str_array[0].replace('firstname=', '');
            var lname = str_array[1].replace('lastname=', '');
            document.getElementById("userCred").innerText = fname + " " + lname;
            var reg = document.getElementById("register");
            var log = document.getElementById("login");
            reg.style.display = "none";
            log.style.display = "none";
        } else {

        }
    }
}
function checkExists(element) {
    if (typeof (element) != 'undefined' && element != null) {
        console.log("Exists.");
    } else {
        console.log("doesnt exists");
    }
}
function returnFalse() {
    return false;
}