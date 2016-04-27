using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway.Data.Entities;

namespace Railway.Data.Services
{

    public class RailwayService
    {
        private readonly RailwayContext context;

        public RailwayService(RailwayContext context)
        {
            this.context = context;
        }

        public Station GetStation(string name)
        {
            return context.Stations.First(x => x.StationName.ToLower() == name.ToLower());
        }

        public List<DailyRoute> GetDailyRoutes(DateTime date, Station startStation, Station destinationStation)
        {
            var result = new List<DailyRoute>();
            var dailyRoutes = context.DailyRoutes.Where(x => x.StartDateTime >= date.Date).ToList(); // берём все ежедневные маршруты не раньше указанной даты
            foreach (var dailyRoute in dailyRoutes)
            {
                var startRouteStation = dailyRoute.Route.RouteStations.FirstOrDefault(x => x.StationId == startStation.StationId);
                var destinationRouteStation = dailyRoute.Route.RouteStations.FirstOrDefault(x => x.StationId == destinationStation.StationId);

                if (startRouteStation != null && destinationRouteStation != null // если на маршруте есть обе указанные станции
                    && startRouteStation.StationOrder < destinationRouteStation.StationOrder // и станция назначения идёт после станции отправления
                    && dailyRoute.StartDateTime.AddMinutes(startRouteStation.MinutesFromStart) < date.Date.AddDays(1)) // и со станции отправления поезд отправляется в указанную дату
                {
                    result.Add(dailyRoute);
                }
            }


            return result;
        }

        public DateTime CalculateArrivalDepartureTime(DailyRoute dailyRoute, Station station)
        {
            var routeStation = dailyRoute.Route.RouteStations.First(x => x.StationId == station.StationId);
            return dailyRoute.StartDateTime.AddMinutes(routeStation.MinutesFromStart);
        }

        public double CalculateCost(DailyRoute dailyRoute, Station startStation, Station destinationStation, CarType carType)
        {
            double cost = 0;
            var routeStations = dailyRoute.Route.RouteStations.OrderBy(x => x.StationOrder).ToList();
            for (var i = 0; i < routeStations.Count - 1; i++)
            {
                var distance = context.Distances.FirstOrDefault(x => x.StartStationId == routeStations[i].StationId && x.DestinationStationId == routeStations[i + 1].StationId);
                if (distance == null)
                {
                    cost += 1;
                }
                else
                {
                    cost += Math.Ceiling(distance.DistanceValue * carType.CostRate);
                }
            }

            return cost;
        }

        public int CalculateAvailableSeats(Car car)
        {
            return  car.CarType.SeatCount - context.OrderPassengers.Count(x => x.CarId == car.CarId);
        }

        public List<List<string>> GetAvailableRoutes()
        {
            var result = new List<List<string>>();

            var routes = context.Routes.ToList();
            foreach (var route in routes)
            {

                var routeStations = context.RouteStations.Where(x => x.RouteId == route.RouteId).OrderBy(x => x.StationOrder);
                var resultStations = routeStations.Select(station => station.Station.StationName).ToList();
                result.Add(resultStations);
            }

            return result;
        }
    }
}
