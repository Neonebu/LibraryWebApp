var mainUrl = window.location.origin;
function RegisterJs() {
    var regform = document.getElementById("registerForm");
    var formData = new FormData(regform);
    var firstname = formData.get("firstname");
    var lastname = formData.get("lastname");
    var bool = false;
    $.ajax({
        type: "POST",
        url: 'Register',
        data: formData,
        processData: false,
        contentType: false,
        async: false,
        success: function (data) {           
            bool = data;
        },
        error: function () {
            bool = false;
            console.log("error");
        }
    });
    if (bool == true) {
        document.cookie = "firstname=" + firstname + "," + "lastname=" + lastname + ",page=0" + ";path=/";
        window.location.replace(mainUrl);
    }
    return bool;
}
function LoginJs() {
    console.log("login")
    var logform = document.getElementById("loginForm");
    var formData = new FormData(logform);
    var firstname = formData.get("firstname");
    var lastname = formData.get("lastname");
    var bool = false;
    $.ajax({
        type: "POST",
        url: 'Login',
        data: formData,
        processData: false,
        contentType: false,
        async: false,
        success: function (data) {
            bool = data;
        },
        error: function () {
            bool = false;
            console.log("error");
        }
    });
    console.log("bool " + bool)
    if (bool == true) {
        document.cookie = "firstname=" + firstname + "," + "lastname=" + lastname + ",page=0" + ";path=/";
        window.location.replace(mainUrl);
    }
    return bool;
}
function logoutJs() {
    var reg = document.getElementById("register");
    var log = document.getElementById("login");
    document.getElementById("userCred").innerText = "";
    deleteAllCookies();
    reg.style.display = "block";
    log.style.display = "block";
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
function deleteAllCookies() {
    const cookies = document.cookie.split(";");

    for (let i = 0; i < cookies.length; i++) {
        const cookie = cookies[i];
        const eqPos = cookie.indexOf("=");
        const name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
        document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
}