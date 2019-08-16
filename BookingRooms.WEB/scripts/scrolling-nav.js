$(document).ready(function () {
    $(".nav-link,.dropdown-item,.homeButton").click(function () {
        var t = $(this).attr("href");
        $('.active').removeClass('active');
        $("html, body").animate({
            scrollTop: $(t).offset().top + 10
        }, {
                duration: 1e3
            });

        $('body').scrollspy({ target: '#mainNav', offset: $(t).offset().top});
        $(this).parent().addClass('active');
        return false;
    });

});

$('body').scrollspy({ target: '#mainNav', offset: 0 });