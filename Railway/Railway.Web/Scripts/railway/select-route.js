function Model(model) {
    var self = this;

    this.input = {
        departureStationName: ko.observable('Minsk'),
        destinationStationName: ko.observable('Bobruisk'),
        departureDate: ko.observable(),
        onlyWithElectronicRegistration: ko.observable(true),
    }

    this.swapStations = function() {
        var first = self.input.departureStationName();
        var second = self.input.destinationStationName();
        self.input.departureStationName(second);
        self.input.destinationStationName(first);
    }

    this.cancel = function() {
        alert('ну и иди нахуй');
    }

    this.submitForm = function () {
    }
}

try {
    ko.applyBindings(new Model(ServerModel));
} catch (e) {
    alert(e.name + ":" + e.message + "\n" + e.stack);
}
