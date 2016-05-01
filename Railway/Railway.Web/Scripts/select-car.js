$(".js-top10-seats").click(function () {
    $(this).parent().find(".js-all-seats").show();
    $(this).hide();
});
$(".js-all-seats").click(function () {
    $(this).parent().find(".js-top10-seats").show();
    $(this).hide();
});

