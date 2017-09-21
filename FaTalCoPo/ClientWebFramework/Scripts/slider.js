$(document).ready(function () {
    $('.slider .slider-item').first().addClass('slider-active-item');


    $('.slider-item').bind("click", function () {
        $('.slider-active-item').removeClass('slider-active-item');
        $(this).addClass('slider-active-item');
    });
});