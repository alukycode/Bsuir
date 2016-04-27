using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Railway.Data.Services;
using Railway.Web.Models;
using Railway.Web.Models.Railway;

namespace Railway.Web.Controllers
{
    public class RailwayController : Controller
    {
        private readonly CarService carService;
        private readonly RailwayService railwayService;

        public RailwayController(CarService carService, RailwayService railwayService)
        {
            this.carService = carService;
            this.railwayService = railwayService;
        }

        [HttpGet]
        public ActionResult SelectRoute()
        {
            var model = new SelectRouteViewModel
            {
                NextStepUrl = Url.Action("SelectTrain"),
                AvailableRoutes = railwayService.GetAvailableRoutes(),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectRoute(SelectRouteSubmitModel model)
        {
            return RedirectToAction("SelectTrain", model);
        }

        public ActionResult SelectTrain(SelectRouteSubmitModel submitModel)
        {
            var startStation = railwayService.GetStation(submitModel.DepartureStation);
            var destinationStation = railwayService.GetStation(submitModel.DestionationStation);

            var dailyRoutes = railwayService.GetDailyRoutes(submitModel.DepartureDate, startStation, destinationStation);
            var trains = new List<SelectTrainViewModel.TrainData>();
            foreach (var dailyRoute in dailyRoutes)
            {
                var startTime = railwayService.CalculateArrivalDepartureTime(dailyRoute, startStation);
                var destionationTime = railwayService.CalculateArrivalDepartureTime(dailyRoute, destinationStation);

                var cars = new List<SelectTrainViewModel.TrainData.CarData>();
                foreach (var car in dailyRoute.Route.Train.Cars)
                {
                    var carData = new SelectTrainViewModel.TrainData.CarData
                    {
                        CarTypeName = car.CarType.TypeName,
                        Cost = railwayService.CalculateCost(dailyRoute, startStation, destinationStation, car.CarType),
                        AvailableSeatCount = railwayService.CalculateAvailableSeats(car),
                    };

                    cars.Add(carData);
                }

                var trainData = new SelectTrainViewModel.TrainData
                {
                    TrainNumber = dailyRoute.Route.Train.TrainNumber,
                    DepartureTime = startTime,
                    ArrivalTime = destionationTime,
                    TripTime = destionationTime - startTime,
                    IsDeLuxe = dailyRoute.Route.Train.IsDeLuxe,
                    IsElectronicRegistrationAvailable = dailyRoute.Route.Train.IsElectronicRegistrationAvailable,
                    IsExpress = dailyRoute.Route.Train.IsElectronicRegistrationAvailable,
                    Cars = cars
                };

                trains.Add(trainData);
            }

            var model = new SelectTrainViewModel
            {
                RouteData = new SelectTrainViewModel.ConfirmedRouteData
                {
                    StartStationId = startStation.StationId,
                    StartStationName = startStation.StationName,
                    DestinationStationId = destinationStation.StationId,
                    DestionationStationName = destinationStation.StationName,
                    DepartureDate = submitModel.DepartureDate
                },
                Trains = trains
            };

            return View(model);
        }

        public ActionResult SelectCar()
        {
            var cars = carService.GetAllCars();
            var model = new SelectCarViewModel
            {
                ArrivalTime = DateTime.Now,
                StartStationName = "start station",
                TrainNumber = "111TRAIN",
                CarTypes = new List<SelectCarViewModel.CarTypesData>
                {
                    new SelectCarViewModel.CarTypesData
                    {
                        CarTypeName = "плацкарт",
                        Cost = 50000,
                        Cars = new List<SelectCarViewModel.CarTypesData.CarData>
                        {
                            new SelectCarViewModel.CarTypesData.CarData
                            {
                                Index = 4,
                                SeatCount = 123,
                                SeatIndexes = new List<int> { 1, 2, 3, 4 }
                            },
                            new SelectCarViewModel.CarTypesData.CarData
                            {
                                Index = 5,
                                SeatCount = 4,
                                SeatIndexes = new List<int> { 4, 5, 6, 7 }
                            }
                        }
                    },
                    new SelectCarViewModel.CarTypesData
                    {
                        CarTypeName = "общий",
                        Cost = 35000,
                        Cars = new List<SelectCarViewModel.CarTypesData.CarData>
                        {
                            new SelectCarViewModel.CarTypesData.CarData
                            {
                                Index = 7,
                                SeatCount = 77,
                                SeatIndexes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 }
                            },
                            new SelectCarViewModel.CarTypesData.CarData
                            {
                                Index = 8,
                                SeatCount = 88,
                                SeatIndexes = new List<int> { 4, 5, 6, 7 }
                            }
                        }
                    }
                }
            };

            return View(model);
        }

        public ActionResult SelectPassenger()
        {
            var model = new SelectPassengerViewModel();
            return View(model);
        }
    }
}