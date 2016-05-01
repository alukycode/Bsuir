using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Railway.Data.Entities;
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

        /// <summary>
        /// step 1: enter stations and date
        /// </summary>
        [HttpGet]
        public ActionResult SelectRoute()
        {
            var model = new SelectRouteViewModel
            {
                AvailableRoutes = railwayService.GetAvailableRoutes(),
                FormModel = new SelectRouteFormModel
                {
                    DepartureStation = "Осиповичи",
                    DestinationStation = "Бобруйск",
                    DepartureDate = DateTime.Now.Date,
                }
            };

            return View(model);
        }

        /// <summary>
        /// step 1: validate data and redirect to next step
        /// </summary>
        [HttpPost]
        public ActionResult SelectRoute([Bind(Prefix = "FormModel")] SelectRouteFormModel form)
        {
            var startStation = railwayService.GetStation(form.DepartureStation);
            var destinationStation = railwayService.GetStation(form.DestinationStation);

            if (startStation == null || destinationStation == null || form.DepartureDate < DateTime.Now.Date)
                return RedirectToAction("SelectRoute");

            form.DepartureStation = startStation.StationName; // минск -> Минск
            form.DestinationStation = startStation.StationName;

            var requestModel = new SelectTrainRequestModel
            {
                StartStationId = startStation.StationId,
                DestinationStationId = destinationStation.StationId,
                DepartureDate = form.DepartureDate
            };

            return RedirectToAction("SelectTrain", requestModel);
        }

        /// <summary>
        /// step 2: choose train
        /// </summary>
        [HttpGet]
        public ActionResult SelectTrain(SelectTrainRequestModel request)
        {
            var dailyRoutes = railwayService.GetDailyRoutes(
                request.DepartureDate,
                request.StartStationId,
                request.DestinationStationId);

            var trains = new List<SelectTrainViewModel.TrainData>();
            foreach (var dailyRoute in dailyRoutes)
            {
                var startTime = railwayService.CalculateArrivalDepartureTime(dailyRoute, request.StartStationId);
                var destinationTime = railwayService.CalculateArrivalDepartureTime(dailyRoute, request.DestinationStationId);

                var cars = new List<SelectTrainViewModel.TrainData.CarTypeData>();
                foreach (var car in dailyRoute.Route.Train.Cars)
                {
                    var carTypesData = new SelectTrainViewModel.TrainData.CarTypeData
                    {
                        CarTypeName = car.CarType.TypeName,
                        Cost = railwayService.CalculateCost(dailyRoute, request.StartStationId, request.DestinationStationId, car.CarType),
                        AvailableSeatCount = railwayService.CalculateAvailableSeats(dailyRoute, car.CarTypeId),
                    };

                    cars.Add(carTypesData);
                }

                var trainData = new SelectTrainViewModel.TrainData
                {
                    DailyRouteId = dailyRoute.DailyRouteId,
                    TrainNumber = dailyRoute.Route.Train.TrainNumber,
                    DepartureTime = startTime,
                    ArrivalTime = destinationTime,
                    TripTime = destinationTime - startTime,
                    IsDeLuxe = dailyRoute.Route.Train.IsDeLuxe,
                    IsElectronicRegistrationAvailable = dailyRoute.Route.Train.IsElectronicRegistrationAvailable,
                    IsExpress = dailyRoute.Route.Train.IsElectronicRegistrationAvailable,
                    Cars = cars
                };

                trains.Add(trainData);
            }

            var formModel = new SelectTrainFormModel()
            {
                StartStationId = request.StartStationId,
                DestinationStationId = request.DestinationStationId,
            };

            var model = new SelectTrainViewModel
            {
                CarTypes = railwayService.GetAllCarTypes(),
                Trains = trains,
                FormModel = formModel
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectTrain([Bind(Prefix = "FormModel")] SelectTrainFormModel form)
        {
            var requestModel = new SelectCarRequestModel
            {
                DailyRouteId = form.DailyRouteId,
                StartStationId = form.StartStationId,
                DestinationStationId = form.DestinationStationId
            };

            return RedirectToAction("SelectCar", requestModel);
        }

        /// <summary>
        /// step 3: choose car
        /// </summary>
        [HttpGet]
        public ActionResult SelectCar(SelectCarRequestModel request)
        {
            var cars = railwayService.GetAllCars(request.DailyRouteId);

            var carTypes = cars.Select(x => x.CarType).Distinct();
            var carTypesData = carTypes.Select(x => new SelectCarViewModel.CarTypeData
            {
                CarTypeId = x.CarTypeId,
                CarTypeName = x.TypeName,
                Cost = railwayService.CalculateCost(request.DailyRouteId, request.StartStationId, request.DestinationStationId, x)
            }).ToList();

            var carsData = cars.Select(x => new SelectCarViewModel.CarData
            {
                CarId = x.CarId,
                CarTypeId = x.CarTypeId,
                Index = x.CarIndex,
                SeatCount = railwayService.CalculateAvailableSeats(x),
                SeatIndexes = railwayService.GetAvailableSeatNumbers(x)
            }).ToList();

            var viewModel = new SelectCarViewModel
            {
                Cars = carsData,
                CarTypes = carTypesData,
                FormModel = new SelectCarFormModel
                {
                    DailyRouteId = request.DailyRouteId,
                    StartStationId = request.DestinationStationId,
                    DestinationStationId = request.DestinationStationId,
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SelectCar([Bind(Prefix = "FormModel")] SelectCarFormModel form)
        {
            var requestModel = new SelectPassengerRequestModel
            {
                CarId = form.CarId,
                StartStationId = form.StartStationId,
                DestinationStationId = form.DestinationStationId,
                DailyRouteId = form.DailyRouteId
            };

            return RedirectToAction("SelectPassenger", requestModel);
        }

        /// <summary>
        /// step 4: select seat indexes and passengers
        /// </summary>
        [HttpGet]
        public ActionResult SelectPassenger(SelectPassengerRequestModel request)
        {
            var passengers = railwayService.GetPassengers();
            var model = new SelectPassengerViewModel();
            return View(model);
        }
    }
}