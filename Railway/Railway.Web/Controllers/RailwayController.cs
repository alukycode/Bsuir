using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Railway.Data.Services;
using Railway.Web.Models;
using Railway.Web.Models.SelectCar;
using Railway.Web.Models.SelectPassenger;
using Railway.Web.Models.SelectRoute;
using Railway.Web.Models.SelectTrain;

namespace Railway.Web.Controllers
{
    public class RailwayController : Controller
    {
        private readonly ICarService carService;

        public RailwayController(ICarService carService)
        {
            this.carService = carService;
        }

        public ActionResult SelectRoute()
        {
            var model = new SelectRouteViewModel
            {
                NextStepUrl = Url.Action("SelectTrain")
            };

            return View(model);
        }

        public ActionResult SelectTrain(SelectRouteSubmitModel submitModel)
        {
            var model = new SelectTrainViewModel
            {
                StartStationName = submitModel.DepartureStation,
                Trains = new List<SelectTrainViewModel.TrainData>
                {
                    new SelectTrainViewModel.TrainData
                    {
                        TrainNumber = "111",
                        DepartureTime = submitModel.DepartureDate,
                        Cars = new List<SelectTrainViewModel.TrainData.CarData>
                        {
                            new SelectTrainViewModel.TrainData.CarData
                            {
                                CarTypeName = "Плацкарт",
                                Cost = 50000,
                                AvailableSeatCount = 15
                            },
                            new SelectTrainViewModel.TrainData.CarData
                            {
                                CarTypeName = "Общий",
                                Cost = 35000,
                                AvailableSeatCount = 4
                            }
                        }
                    },
                    new SelectTrainViewModel.TrainData
                    {
                        TrainNumber = "222",
                        DepartureTime = DateTime.Now.AddDays(123),
                        Cars = new List<SelectTrainViewModel.TrainData.CarData>
                        {
                            new SelectTrainViewModel.TrainData.CarData
                            {
                                CarTypeName = "Сидячие",
                                Cost = 350,
                                AvailableSeatCount = 245
                            },
                            new SelectTrainViewModel.TrainData.CarData
                            {
                                CarTypeName = "Общий",
                                Cost = 35000,
                                AvailableSeatCount = 5
                            }
                        }
                    }
                }
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