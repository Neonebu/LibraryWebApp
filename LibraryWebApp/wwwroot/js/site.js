var mainUrl = window.location.origin;
function RegisterJs() {
    var regform = document.getElementById("registerForm");
    var formData = new FormData(regform);
    $.ajax({
        type: "POST",
        url: 'Register',
        data: formData,
        processData: false,
        contentType: false,
        success: function () {
            alert('success');
        },
        error: function () {
            alert('failure');
        }
    });
}
function checkExists(element) {
    if (typeof (element) != 'undefined' && element != null) {
        console.log("Exists.");
    } else {
        console.log("doesnt exists");
    }
}