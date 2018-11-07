$("#main-image").mouseout(zoomOut);
$("#main-image").mousemove(function (event) {
    zoomIn(event);
});

function zoomIn(event) {
    var $element = $("#shop-overlay-image");
    $element.css('display', 'inline-block');
    var $img = $("#main-image");
    var posX = event.offsetX ? (event.offsetX) : event.pageX - $img.css('offsetLeft');
    var posY = event.offsetY ? (event.offsetY) : event.pageY - $img.css('offsetTop');
    var imageElement = document.getElementById("main-image");
    var realImageWidth = imageElement.naturalWidth;
    var realImageHeight = imageElement.naturalHeight;
    var imageHeightRatio = (realImageHeight / $img.outerHeight());
    var imageWidthRatio = (realImageWidth / $img.outerWidth());
    var backgroundPosition = ((-posX * imageWidthRatio) + 150) + "px " + ((-posY * imageHeightRatio) + 150) + "px";
    $element.css('backgroundPosition', backgroundPosition);
}

function zoomOut() {
    var $element = $("#shop-overlay-image");
    $element.css('display', 'none');
}

$(".image-picker-wrapper").click(function () {
    var $imageClicked = $(this).find("img").first();
    var imageSource = $imageClicked.attr('src');
    $("#shop-overlay-image").css('background-image', 'url(' + imageSource + ')');
    $("#main-image").attr('src', imageSource);
});

$("#zoom-image-button").click(() => {
    $("#outer-zoomed-image-wrapper").show();
    $("#outer-zoomed-image-wrapper img").attr('src', $("#main-image").attr('src'));
});

$("#outer-zoomed-image-wrapper .close-button").click(() => {
    $("#outer-zoomed-image-wrapper").hide();
});