namespace Railway.Web.Models.Railway
{
    public class SelectPassengerFormModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentNumer { get; set; }
        public int MinSeat { get; set; }
        public int MaxSeat { get; set; }

        public int DailyRouteId { get; set; }
        public int StartStationId { get; set; }
        public int DestinationStationId { get; set; }
        public int CarId { get; set; }
    }
}