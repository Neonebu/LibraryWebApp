// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Get the elements by their ID
//var popupLink = document.getElementById("register-btn"); form direkt controller'a gitsin diye commente çektim. vievbag ile çözüm düşündüm. 
var popupWindow = document.getElementById("popup-window");
var closeButton = document.getElementById("close-register-button");
// Show the pop-up window when the link is clicked
popupLink.addEventListener("click", function (event) {
    event.preventDefault();
    popupWindow.style.display = "block";
});

// Hide the pop-up window when the close button is clicked
closeButton.addEventListener("click", function () {
    popupWindow.style.display = "none";
});
function Register() {
    $.ajax({
        type: "POST",
        url: '/HomeController/Register'
    }).done(function () {
        alert('Test');
    });
}
$("#registerForm").on("submit", function (event) {
    event.preventDefault(); 
    alert("Handler for `submit` called.");
});
function Hide(id) {
    alert(id);
}