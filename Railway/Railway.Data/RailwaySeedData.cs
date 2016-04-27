using System;
using System.Collections.Generic;
using System.Data.Entity;
using Railway.Data.Entities;

namespace Railway.Data
{
    public class RailwaySeedData : DropCreateDatabaseAlways<RailwayContext>
    {
        protected override void Seed(RailwayContext context)
        {
            context.CarTypes.AddRange(GetCarTypes());
            context.Stations.AddRange(GetStations());
            context.SaveChanges();
            context.Trains.AddRange(GetTrains());
            context.SaveChanges();
            context.Cars.AddRange(GetCars());
            context.SaveChanges();
            context.Routes.AddRange(GetRoutes());
            context.SaveChanges();
            context.RouteStations.AddRange(GetRouteStations());
            context.DailyRoutes.AddRange(GetDailyRoutes());
            context.Users.AddRange(GetUsers());
            context.SaveChanges();
            context.Passengers.AddRange(GetPassengers());
            context.SaveChanges();
        }

        private static List<Train> GetTrains()
        {
            return new List<Train>
            {
                new Train { TrainNumber = "737Б", IsElectronicRegistrationAvailable = true, IsExpress = true, IsDeLuxe = true },
                new Train { TrainNumber = "738Б", IsElectronicRegistrationAvailable = true, IsExpress = true, IsDeLuxe = true },
                new Train { TrainNumber = "743Б", IsElectronicRegistrationAvailable = true, IsExpress = true, IsDeLuxe = false },
                new Train { TrainNumber = "744Б", IsElectronicRegistrationAvailable = true, IsExpress = true, IsDeLuxe = false },
                new Train { TrainNumber = "631Ф", IsElectronicRegistrationAvailable = false, IsExpress = true, IsDeLuxe = true },
                new Train { TrainNumber = "632Ф", IsElectronicRegistrationAvailable = false, IsExpress = true, IsDeLuxe = true },
                new Train { TrainNumber = "007Й", IsElectronicRegistrationAvailable = false, IsExpress = true, IsDeLuxe = false },
                new Train { TrainNumber = "008Й", IsElectronicRegistrationAvailable = false, IsExpress = true, IsDeLuxe = false },
            };
        }

        private static List<CarType> GetCarTypes()
        {
            return new List<CarType>
            {
                new CarType { TypeName = "Общий", CostRate = 1, SeatCount = 90, },
                new CarType { TypeName = "Плацкарт", CostRate = 1.3, SeatCount = 60, },
                new CarType { TypeName = "Купе", CostRate = 1.6, SeatCount = 36, },
                new CarType { TypeName = "СВ", CostRate = 2, SeatCount = 18, },
                new CarType { TypeName = "Бизнес-класс", CostRate = 1.5, SeatCount = 50, },
            };
        }

        private static List<Car> GetCars()
        {
            return new List<Car>
            {
                new Car {  TrainId = 1, CarIndex = 1, CarTypeId = 5 },
                new Car {  TrainId = 1, CarIndex = 2, CarTypeId = 5 },
                new Car {  TrainId = 1, CarIndex = 3, CarTypeId = 5 },
                new Car {  TrainId = 1, CarIndex = 4, CarTypeId = 5 },
                new Car {  TrainId = 1, CarIndex = 5, CarTypeId = 5 },

                new Car {  TrainId = 2, CarIndex = 1, CarTypeId = 5 },
                new Car {  TrainId = 2, CarIndex = 2, CarTypeId = 5 },
                new Car {  TrainId = 2, CarIndex = 3, CarTypeId = 5 },
                new Car {  TrainId = 2, CarIndex = 4, CarTypeId = 5 },
                new Car {  TrainId = 2, CarIndex = 5, CarTypeId = 5 },

                new Car {  TrainId = 3, CarIndex = 1, CarTypeId = 5 },
                new Car {  TrainId = 3, CarIndex = 2, CarTypeId = 5 },
                new Car {  TrainId = 3, CarIndex = 3, CarTypeId = 5 },
                new Car {  TrainId = 3, CarIndex = 4, CarTypeId = 5 },
                new Car {  TrainId = 3, CarIndex = 5, CarTypeId = 5 },
                new Car {  TrainId = 3, CarIndex = 6, CarTypeId = 5 },
                new Car {  TrainId = 3, CarIndex = 7, CarTypeId = 5 },
                new Car {  TrainId = 3, CarIndex = 8, CarTypeId = 5 },
                new Car {  TrainId = 3, CarIndex = 9, CarTypeId = 5 },

                new Car {  TrainId = 4, CarIndex = 1, CarTypeId = 5 },
                new Car {  TrainId = 4, CarIndex = 2, CarTypeId = 5 },
                new Car {  TrainId = 4, CarIndex = 3, CarTypeId = 5 },
                new Car {  TrainId = 4, CarIndex = 4, CarTypeId = 5 },
                new Car {  TrainId = 4, CarIndex = 5, CarTypeId = 5 },
                new Car {  TrainId = 4, CarIndex = 6, CarTypeId = 5 },
                new Car {  TrainId = 4, CarIndex = 7, CarTypeId = 5 },
                new Car {  TrainId = 4, CarIndex = 8, CarTypeId = 5 },
                new Car {  TrainId = 4, CarIndex = 9, CarTypeId = 5 },

                new Car {  TrainId = 5, CarIndex = 1, CarTypeId = 1 },
                new Car {  TrainId = 5, CarIndex = 2, CarTypeId = 1 },
                new Car {  TrainId = 5, CarIndex = 3, CarTypeId = 2 },
                new Car {  TrainId = 5, CarIndex = 4, CarTypeId = 2 },
                new Car {  TrainId = 5, CarIndex = 5, CarTypeId = 2 },
                new Car {  TrainId = 5, CarIndex = 6, CarTypeId = 3 },
                new Car {  TrainId = 5, CarIndex = 7, CarTypeId = 3 },
                new Car {  TrainId = 5, CarIndex = 8, CarTypeId = 3 },
                new Car {  TrainId = 5, CarIndex = 9, CarTypeId = 4 },
                new Car {  TrainId = 5, CarIndex = 10, CarTypeId = 2 },

                new Car {  TrainId = 6, CarIndex = 1, CarTypeId = 1 },
                new Car {  TrainId = 6, CarIndex = 2, CarTypeId = 1 },
                new Car {  TrainId = 6, CarIndex = 3, CarTypeId = 2 },
                new Car {  TrainId = 6, CarIndex = 4, CarTypeId = 2 },
                new Car {  TrainId = 6, CarIndex = 5, CarTypeId = 2 },
                new Car {  TrainId = 6, CarIndex = 6, CarTypeId = 3 },
                new Car {  TrainId = 6, CarIndex = 7, CarTypeId = 3 },
                new Car {  TrainId = 6, CarIndex = 8, CarTypeId = 3 },
                new Car {  TrainId = 6, CarIndex = 9, CarTypeId = 4 },
                new Car {  TrainId = 6, CarIndex = 10, CarTypeId = 2 },

                new Car {  TrainId = 7, CarIndex = 7, CarTypeId = 4 },

                new Car {  TrainId = 8, CarIndex = 8, CarTypeId = 4 }
            };
        }

        private static List<Route> GetRoutes()
        {
            return new List<Route>
            {
                new Route { TrainId = 1 },
                new Route { TrainId = 2 },
                new Route { TrainId = 3 },
                new Route { TrainId = 4 },
                new Route { TrainId = 5 },
                new Route { TrainId = 6 },
                new Route { TrainId = 7 },
                new Route { TrainId = 8 },
            };
        }

        private static List<Station> GetStations()
        {
            return new List<Station>
            {
                new Station { StationName = "Гомель" },
                new Station { StationName = "Жлобин" },
                new Station { StationName = "Калинковичи" },
                new Station { StationName = "Слуцк" }, //4

                new Station { StationName = "Могилев" },
                new Station { StationName = "Бобруйск" },
                new Station { StationName = "Осиповичи" },
                new Station { StationName = "Кричев" }, //8

                new Station { StationName = "Минск" },
                new Station { StationName = "Жодино" },
                new Station { StationName = "Солигорск" },
                new Station { StationName = "Молодечно" }, //12

                new Station { StationName = "Гродно" },
                new Station { StationName = "Лида" },
                new Station { StationName = "Волковыск" }, //15

                new Station { StationName = "Витебск" },
                new Station { StationName = "Полоцк" },
                new Station { StationName = "Орша" }, //18

                new Station { StationName = "Брест" },
                new Station { StationName = "Барановичи" },
                new Station { StationName = "Лунинец" } //21
            };
        }

        private static List<RouteStation> GetRouteStations()
        {
            return new List<RouteStation>
            {
                new RouteStation { RouteId = 1, StationId = 1, MinutesFromStart = 0, StationOrder = 1 },
                new RouteStation { RouteId = 1, StationId = 2, MinutesFromStart = 15, StationOrder = 2 },
                new RouteStation { RouteId = 1, StationId = 6, MinutesFromStart = 30, StationOrder = 3 },
                new RouteStation { RouteId = 1, StationId = 7, MinutesFromStart = 45, StationOrder = 4 },
                new RouteStation { RouteId = 1, StationId = 9, MinutesFromStart = 60, StationOrder = 5 },
                new RouteStation { RouteId = 1, StationId = 12, MinutesFromStart = 75, StationOrder = 6 },

                new RouteStation { RouteId = 2, StationId = 1, MinutesFromStart = 75, StationOrder = 6 },
                new RouteStation { RouteId = 2, StationId = 2, MinutesFromStart = 60, StationOrder = 5 },
                new RouteStation { RouteId = 2, StationId = 6, MinutesFromStart = 45, StationOrder = 4 },
                new RouteStation { RouteId = 2, StationId = 7, MinutesFromStart = 30, StationOrder = 3 },
                new RouteStation { RouteId = 2, StationId = 9, MinutesFromStart = 15, StationOrder = 2 },
                new RouteStation { RouteId = 2, StationId = 12, MinutesFromStart = 0, StationOrder = 1 },

                new RouteStation { RouteId = 3, StationId = 19, MinutesFromStart = 0, StationOrder = 1 },
                new RouteStation { RouteId = 3, StationId = 20, MinutesFromStart = 15, StationOrder = 2 },
                new RouteStation { RouteId = 3, StationId = 9, MinutesFromStart = 30, StationOrder = 3 },
                new RouteStation { RouteId = 3, StationId = 18, MinutesFromStart = 45, StationOrder = 4 },
                new RouteStation { RouteId = 3, StationId = 16, MinutesFromStart = 60, StationOrder = 5 },
                new RouteStation { RouteId = 3, StationId = 17, MinutesFromStart = 75, StationOrder = 6 },

                new RouteStation { RouteId = 4, StationId = 19, MinutesFromStart = 75, StationOrder = 6 },
                new RouteStation { RouteId = 4, StationId = 20, MinutesFromStart = 60, StationOrder = 5 },
                new RouteStation { RouteId = 4, StationId = 9, MinutesFromStart = 45, StationOrder = 4 },
                new RouteStation { RouteId = 4, StationId = 18, MinutesFromStart = 30, StationOrder = 3 },
                new RouteStation { RouteId = 4, StationId = 16, MinutesFromStart = 15, StationOrder = 2 },
                new RouteStation { RouteId = 4, StationId = 17, MinutesFromStart = 0, StationOrder = 1 },

                new RouteStation { RouteId = 5, StationId = 13, MinutesFromStart = 0, StationOrder = 1 },
                new RouteStation { RouteId = 5, StationId = 15, MinutesFromStart = 15, StationOrder = 2 },
                new RouteStation { RouteId = 5, StationId = 20, MinutesFromStart = 30, StationOrder = 3 },
                new RouteStation { RouteId = 5, StationId = 4, MinutesFromStart = 45, StationOrder = 4 },
                new RouteStation { RouteId = 5, StationId = 7, MinutesFromStart = 60, StationOrder = 5 },
                new RouteStation { RouteId = 5, StationId = 6, MinutesFromStart = 75, StationOrder = 6 },
                new RouteStation { RouteId = 5, StationId = 2, MinutesFromStart = 90, StationOrder = 7 },
                new RouteStation { RouteId = 5, StationId = 1, MinutesFromStart = 105, StationOrder = 8 },
                new RouteStation { RouteId = 5, StationId = 3, MinutesFromStart = 120, StationOrder = 9 },

                new RouteStation { RouteId = 6, StationId = 13, MinutesFromStart = 120, StationOrder = 9 },
                new RouteStation { RouteId = 6, StationId = 15, MinutesFromStart = 105, StationOrder = 8 },
                new RouteStation { RouteId = 6, StationId = 20, MinutesFromStart = 90, StationOrder = 7 },
                new RouteStation { RouteId = 6, StationId = 4, MinutesFromStart = 75, StationOrder = 6 },
                new RouteStation { RouteId = 6, StationId = 7, MinutesFromStart = 60, StationOrder = 5 },
                new RouteStation { RouteId = 6, StationId = 6, MinutesFromStart = 45, StationOrder = 4 },
                new RouteStation { RouteId = 6, StationId = 2, MinutesFromStart = 30, StationOrder = 3 },
                new RouteStation { RouteId = 6, StationId = 1, MinutesFromStart = 15, StationOrder = 2 },
                new RouteStation { RouteId = 6, StationId = 3, MinutesFromStart = 0, StationOrder = 1 },

                new RouteStation { RouteId = 7, StationId = 16, MinutesFromStart = 0, StationOrder = 1 },
                new RouteStation { RouteId = 7, StationId = 18, MinutesFromStart = 15, StationOrder = 2 },
                new RouteStation { RouteId = 7, StationId = 8, MinutesFromStart = 30, StationOrder = 3 },
                new RouteStation { RouteId = 7, StationId = 5, MinutesFromStart = 45, StationOrder = 4 },
                new RouteStation { RouteId = 7, StationId = 6, MinutesFromStart = 60, StationOrder = 5 },
                new RouteStation { RouteId = 7, StationId = 7, MinutesFromStart = 75, StationOrder = 6 },
                new RouteStation { RouteId = 7, StationId = 9, MinutesFromStart = 90, StationOrder = 7 },

                new RouteStation { RouteId = 8, StationId = 16, MinutesFromStart = 90, StationOrder = 7 },
                new RouteStation { RouteId = 8, StationId = 18, MinutesFromStart = 75, StationOrder = 6 },
                new RouteStation { RouteId = 8, StationId = 8, MinutesFromStart = 60, StationOrder = 5 },
                new RouteStation { RouteId = 8, StationId = 5, MinutesFromStart = 45, StationOrder = 4 },
                new RouteStation { RouteId = 8, StationId = 6, MinutesFromStart = 30, StationOrder = 3 },
                new RouteStation { RouteId = 8, StationId = 7, MinutesFromStart = 15, StationOrder = 2 },
                new RouteStation { RouteId = 8, StationId = 9, MinutesFromStart = 0, StationOrder = 1 },
            };
        }

        private static List<DailyRoute> GetDailyRoutes()
        {
            var result = new List<DailyRoute>();

            for (var precalculatedDays = 0; precalculatedDays < 10; precalculatedDays++)
            {
                for (var routeId = 1; routeId <= 8; routeId++)
                {
                    // чётные обратные маршруты на два часа позже
                    var startDateTime = routeId % 2 == 0 ? DateTime.Now.AddHours(2) : DateTime.Now;
                    result.Add(new DailyRoute { RouteId = routeId, StartDateTime = startDateTime });
                }
            }

            return result;
        }

        private static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Email = "first@example.com",
                    Login = "first",
                    Password = "password1",
                    FirstName = "Anton",
                    LastName = "Lukyanov",
                    Phone = "+37544 7013002"
                },
                new User
                {
                    Email = "second@example.com",
                    Login = "second",
                    Password = "password2",
                    FirstName = "Roman",
                    LastName = "Vakulchik",
                    Phone = "+37533 1234567"
                },
                new User
                {
                    Email = "third@example.com",
                    Login = "third",
                    Password = "password3",
                    FirstName = "Sasha",
                    LastName = "Chernogrebel",
                    Phone = "+37529 7654321"
                },
            };
        }

        private static List<Passenger> GetPassengers()
        {
            return new List<Passenger>
            {
                new Passenger
                {
                    UserId = 1,
                    FullName = "Лукьянов Антон Александрович",
                    IdentificationType = 2,
                    IdentificationNumber = "1234567890"
                },
                new Passenger
                {
                    UserId = 1,
                    FullName = "Федосеева Татьяна Андреевна",
                    IdentificationType = 1,
                    IdentificationNumber = "KB16859000"
                },
                new Passenger
                {
                    UserId = 2,
                    FullName = "Вакульчик Роман Николаевич",
                    IdentificationType = 1,
                    IdentificationNumber = "HB54321000"
                },
                new Passenger
                {
                    UserId = 3,
                    FullName = "Черногребель Александр Михайлович",
                    IdentificationType = 1,
                    IdentificationNumber = "CH1010101"
                },
            };
        }
    }
}
