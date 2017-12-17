$("#garvan-entertainment-shop-button").click(() => {
    window.location.href = '/Contact';
});

$("a.chapter-link").on('click', function (event) {
    if (this.hash !== "") {
        event.preventDefault();
        var hash = this.hash;
        $('html, body').animate({
            scrollTop: $(hash).offset().top - 70
        }, 800);
    }
});

$(window).scroll(function () {
    $("a.chapter-nav-link").removeClass("selected-chapter");

    var chapterLinks = $("a.chapter-nav-link");
    for (var i = 0; i < chapterLinks.length; i++) {
        var linkHash = chapterLinks[i].hash;
        var elementIsVisible = isScrolledIntoView(linkHash);
        if (elementIsVisible) {
            $("a.chapter-nav-link[href='" + linkHash + "']").addClass("selected-chapter");
            return;
        }
    }
});

function isScrolledIntoView(elem) {
    var docViewTop = $(window).scrollTop();
    var docViewBottom = docViewTop + $(window).height();

    var elemTop = $(elem).offset().top;
    var elemBottom = elemTop + $(elem).height();

    return ((elemBottom <= docViewBottom) && (elemTop >= docViewTop));
}