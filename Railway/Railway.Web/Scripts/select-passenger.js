function DocumentType(id, name) {
    this.Name = name;
    this.Id = id;
}

function ViewModel(model) {
    var self = this;

    this.availableDocumentTypes = model.DocumentTypes;
    this.availablePassengers = ko.observableArray(model.SavedPassengers);

    this.lastName = ko.observable("");
    this.firstName = ko.observable("");
    this.documentType = ko.observable(1);
    this.documentNumber = ko.observable("");

    this.minSeat = ko.observable(model.MinSeat);
    this.maxSeat = ko.observable(model.MaxSeat);

    this.selectPassenger = function (data) {
        self.lastName(data.LastName);
        self.firstName(data.FirstName);
        self.documentType(data.DocumentTypeId);
        self.documentNumber(data.DocumentNumber);
    }

    this.submitForm = function() {
        $.ajax({
            url: model.SubmitUrl,
            method: "post",
            data: {
                DailyRouteId: model.DailyRouteId,
                CarId: model.CarId,
                StartStationId: model.StartStationId,
                DestinationStationId: model.DestinationStationId,
                FirstName: self.firstName(),
                LastName: self.lastName(),
                DocumentTypeId: self.documentType(),
                DocumentNumer: self.documentNumber(),
                MinSeat: self.minSeat(),
                MaxSeat: self.maxSeat()
            },
            success: function(response) {
                if (response.Success) {
                    location.href = response.RedirectUrl;
                } else {
                    alert(response.Message);
                }
            },
            error: function() {
                alert("ajax error!");
            }
        });
    }
}

try {
    ko.applyBindings(new ViewModel(ServerModel));
} catch (ex) {
    alert(ex.message);
}