var mainUrl = window.location.origin;
function RegisterJs() {
    var regform = document.getElementById("registerForm");
    var formData = new FormData(regform);
    var firstname = formData.get("firstname");
    var lastname = formData.get("lastname");
    $.ajax({
        type: "POST",
        url: 'Register',
        data: formData,
        processData: false,
        contentType: false,
        success: function () {
            document.cookie = "firstname=" + firstname + "," + "lastname=" + lastname + ",page=0" + ";path=/";
            window.location.replace(mainUrl);
        },
        error: function () {
        }
    });
}
function userCred() {
    var str_array = document.cookie.split(',');
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
function checkExists(element) {
    if (typeof (element) != 'undefined' && element != null) {
        console.log("Exists.");
    } else {
        console.log("doesnt exists");
    }
}