﻿$(document).ready(() => {
    var resources = {
        SomethingHappened: "",
        EnterValidEmail: "",
        ErrorOccurred: "",
        EmailSuccessfullyRegistered: "",
        EnterValidCount: ""
    };

    $("#shop-button").click(() => {
        window.location.href = '/Shop';
    });

    $(".garvan-story-button").click(() => {
        window.location.href = '/Story';
    });

    $(".chapter-link").on('click', function (event) {
        event.preventDefault();
        if (this.hash !== "") {
            var hash = this.hash;
            $('html, body').animate({
                scrollTop: $(hash).offset().top - 120
            }, 800);
        }
    });

    $(window).scroll(function () {
        $(".chapter-nav-link").removeClass("selected-chapter");

        var chapterLinks = $(".chapter-nav-link");
        for (var i = 0; i < chapterLinks.length; i++) {
            var linkHash = chapterLinks[i].hash;
            if (!linkHash) {
                continue;
            }

            var elementIsVisible = isScrolledIntoView(linkHash);
            if (elementIsVisible) {
                $(".chapter-nav-link[href='" + linkHash + "']").addClass("selected-chapter");
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
        loadResources(() => {
            var $subscribeDiv = $(this).closest("#subscribe-div");
            var $emailInput = $subscribeDiv.find(".email-subscribe-input");
            if (!$emailInput) {
                displayErrorMessage($subscribeDiv, resources.SomethingHappened);
                return;
            }

            var emailEntered = $emailInput.val();
            if (!emailEntered || !isEmail(emailEntered)) {
                displayErrorMessage($subscribeDiv, resources.EnterValidEmail);
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
                    displayErrorMessage($subscribeDiv, resources.ErrorOccurred);
                },
                success: function (response) {
                    if (response != null && response.success) {
                        displayInfoMessage($subscribeDiv, resources.EmailSuccessfullyRegistered);
                        $emailInput.val('');
                    } else {
                        displayErrorMessage($subscribeDiv, response.responseText);
                    }
                }
            }).always(function () {
                $loadingWrapper.addClass("hidden");
            });
        });
    });

    function displayErrorMessage($subscribeDiv, message) {
        var $subscribeErrorWrapper = $subscribeDiv.find(".error-wrapper");
        var $subscribeErrorMessage = $subscribeErrorWrapper.find(".error-message");
        $subscribeErrorMessage.html(message);
        $subscribeErrorWrapper.removeClass("hidden");
    }

    function displayInfoMessage($subscribeDiv, message) {
        var $subscribeInfoWrapper = $subscribeDiv.find(".info-wrapper");
        var $subscribeInfoMessage = $subscribeInfoWrapper.find(".info-message");
        $subscribeInfoMessage.html(message);
        $subscribeInfoWrapper.removeClass("hidden");
    }

    $(".error-close-button").click(function (event) {
        var $subscribeErrorWrapper = $(this).closest(".error-wrapper");
        $subscribeErrorWrapper.addClass("hidden");
    });

    $(".info-close-button").click(function (event) {
        var $subscribeErrorWrapper = $(this).closest(".info-wrapper");
        $subscribeErrorWrapper.addClass("hidden");
    });

    function isEmail(email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    }

    $("#garvan-contact-form").submit(function (event) {
        event.preventDefault();
        var $form = $(this);

        loadResources(() => {
            var $formParent = $form.closest("div");
            var emailEntered = $form.find("#contactEmailInput").val();
            if (!emailEntered || !isEmail(emailEntered)) {
                displayErrorMessage($formParent, resources.EnterValidEmail);
                return;
            }

            //form encoded data
            var dataType = 'application/x-www-form-urlencoded; charset=utf-8';
            var data = $form.serialize();
            disableContactForm($form, true);

            var $loadingWrapper = $formParent.find(".loading-wrapper");
            $loadingWrapper.removeClass("hidden");

            $.ajax({
                url: 'Contact/SendEmail',
                type: 'POST',
                contentType: dataType,
                dataType: 'json',
                data: data
            })
                .done(function (response) {
                    if (response != null && response.success) {
                        displayInfoMessage($formParent, response.responseText);
                        clearContactForm($form);
                    } else {
                        displayErrorMessage($formParent, response.responseText);
                    }

                    disableContactForm($form, false);
                    $loadingWrapper.addClass("hidden");
                });
        });
    });

    $("#garvan-shop-form").submit(function (event) {
        event.preventDefault();
        var $form = $(this);

        loadResources(() => {
            var $formParent = $form.closest("div");
            var emailEntered = $form.find("#shopEmailInput").val();
            if (!emailEntered || !isEmail(emailEntered)) {
                displayErrorMessage($formParent, resources.EnterValidEmail);
                return;
            }

            var countEntered = $form.find("#shopCountInput").val();
            if (!countEntered) {
                displayErrorMessage($formParent, resources.EnterValidCount);
                return;
            }

            var countNumber = parseInt(countEntered, 10);
            if (countNumber < 0) {
                displayErrorMessage($formParent, resources.EnterValidCount);
                return;
            }

            var itemName = $form.find(".shop-item-header").text().trim();
            var itemPrice = parseInt($form.find(".shop-object-price-current").text().trim());

            var dataType = 'application/json';
            var serializedFormData = getFormData($form);

            var formData = {
                name: serializedFormData['name'],
                email: serializedFormData['email'],
                shopObjects: [{
                    count: countNumber,
                    name: itemName,
                    price: itemPrice
                }],
                subject: serializedFormData['subject'],
                message: serializedFormData['message'],
                'recaptcha-response': serializedFormData['g-recaptcha-response']
            };

            disableContactForm($form, true);

            var $loadingWrapper = $formParent.find(".loading-wrapper");
            $loadingWrapper.removeClass("hidden");

            $.ajax({
                url: 'Shop/SendBasketEmail',
                type: 'POST',
                contentType: dataType,
                dataType: 'json',
                data: JSON.stringify(formData),
            })
                .done(function (response) {
                    if (response != null && response.success) {
                        displayInfoMessage($formParent, response.responseText);
                        clearContactForm($form);
                    } else {
                        displayErrorMessage($formParent, response.responseText);
                    }

                    disableContactForm($form, false);
                    $loadingWrapper.addClass("hidden");
                });
        });
    });

    function getFormData($form) {
        var unindexed_array = $form.serializeArray();
        var indexed_array = {};

        $.map(unindexed_array, function (n, i) {
            indexed_array[n['name']] = n['value'];
        });

        return indexed_array;
    }

    function disableContactForm($contactForm, isEnabled) {
        $contactForm.find("input").prop("disabled", isEnabled);
        $contactForm.find("textarea").prop("disabled", isEnabled);
        $contactForm.find("button").prop("disabled", isEnabled);
    }

    function clearContactForm($contactForm) {
        $contactForm.find("input").val('');
        $contactForm.find("textarea").val('');
        $contactForm.find("button").val('');
    }

    function loadResources(callbackFunc) {
        if (resources.SomethingHappened) {
            callbackFunc();
            return;
        }

        $.ajax({
            url: 'Subscribe/GetRequiredResources',
            type: 'GET'
        })
            .success(function (response) {
                resources.SomethingHappened = response.somethingHappened;
                resources.EnterValidEmail = response.enterValidEmail;
                resources.EnterValidCount = response.enterValidCount;
                resources.ErrorOccurred = response.errorOccurred;
                resources.EmailSuccessfullyRegistered = response.emailSuccessfullyRegistered;

                callbackFunc();
            });
    }
});