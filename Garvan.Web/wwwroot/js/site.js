$(document).ready(() => {

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

    $(".subscribe-register-form").on('submit', function (event) {
        event.preventDefault();
        var $subscribeDiv = $(this).closest("#subscribe-div");
        var $emailInput = $subscribeDiv.find(".email-subscribe-input");
        if (!$emailInput) {
            displaySubscribeError($subscribeDiv, "Something happened. Please try again");
            return;
        }

        var emailEntered = $emailInput.val();
        if (!emailEntered || !isEmail(emailEntered)) {
            displaySubscribeError($subscribeDiv, "Please enter valid e-mail address");
            return;
        }

        var $loadingWrapper = $subscribeDiv.find(".loading-wrapper");
        $loadingWrapper.removeClass("hidden");
        $.ajax({
            type: "POST",
            url: "/Subscribe/AddEmail",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(emailEntered),
            dataType: "json",
            error: function (xhr, status, errorThrown) {
                displaySubscribeError($subscribeDiv, "Error occurred. Please try again");
            },
            success: function (response) {
                if (response != null && response.success) {
                    displaySubscribeInfo($subscribeDiv, "Your e-mail was successfully registered.<br/>Stay tuned for more news from Garvan.");
                    $emailInput.val('');
                } else {
                    displaySubscribeError($subscribeDiv, response.responseText);
                }
            }
        }).always(function () {
            $loadingWrapper.addClass("hidden");
        });
    });

    function displaySubscribeError($subscribeDiv, message) {
        var $subscribeErrorWrapper = $subscribeDiv.find(".subscribe-error-wrapper");
        var $subscribeErrorMessage = $subscribeErrorWrapper.find(".subscribe-error-message");
        $subscribeErrorMessage.html(message);
        $subscribeErrorWrapper.removeClass("hidden");
    }

    function displaySubscribeInfo($subscribeDiv, message) {
        var $subscribeInfoWrapper = $subscribeDiv.find(".subscribe-info-wrapper");
        var $subscribeInfoMessage = $subscribeInfoWrapper.find(".subscribe-info-message");
        $subscribeInfoMessage.html(message);
        $subscribeInfoWrapper.removeClass("hidden");
    }

    $(".subscribe-error-close-button").click(function (event) {
        var $subscribeErrorWrapper = $(this).closest(".subscribe-error-wrapper");
        $subscribeErrorWrapper.addClass("hidden");
    });

    $(".subscribe-info-close-button").click(function (event) {
        var $subscribeErrorWrapper = $(this).closest(".subscribe-info-wrapper");
        $subscribeErrorWrapper.addClass("hidden");
    });

    function isEmail(email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    }
});