var $firstStation = $("#FormModel_DepartureStation");
var $secondStation = $("#FormModel_DestinationStation");

//$firstStation.on("change", function() {
    
//});

$("#js-swap-stations").click(function() {
    var first = $firstStation.val();
    var second = $secondStation.val();
    $firstStation.val(second);
    $secondStation.val(first);
});

$(document).ready(function() {
    $(".datepicker").datepicker({
        language: "ru"
    });
});
