//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.




function browsernotify(data) {
    if (!("Notification") in window)
        alert(data.Title)
}
var option = {
    body: data.title,
    dir: "rtl",
    icon: "/"
};
if (Notification.permission == "granted") {
    var notification = new Notification(data.title, option);
    notification.onclick = function (event) {
        event.preventDefault;
        notification.close();
    }

} else if (Notification.permission != "granted") {
    Notification.requestPermission().then(function (permission) {
        if (permission == "garented")
         var notification = new Notification("", option);
         notification.onclick = function (event) {
             event.preventDefault;
             notification.close();
    }

})
}
