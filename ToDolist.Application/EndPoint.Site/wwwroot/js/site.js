//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.




function startloading(element = 'body') {
    $(element).waitMe({
        effect: 'stretch',
        text: 'صبر کن!',
        bg: 'rgba(255, 255, 255, 0.7)',
        color: '#000' 

});
}
function closeloading(element = 'body') {
    $(element).waitMe('hide');

}

//function laodmodalforedit(cartId) {
//    $.ajax({
//        url: "/load-Edit-modal-body",
//        type: "get",
//        data: {

//        },
//        beforesend: function () {
            
//            startloading();
//        },
//        success: function (response) {
//            closeloading();
//            console.log(response)
//        },
//        error: function () {
//            closeloading();

//        }

//    });
//}
