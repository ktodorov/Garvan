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

        debugger;
        $("a.chapter-nav-link").removeClass("selected-chapter");
        $("a.chapter-nav-link[href='" + hash + "']").addClass("selected-chapter");
    }
});
