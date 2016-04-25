using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway.Models.Models;
using Railway.Repositories.Infrastructure;
using Railway.Repositories.Repositories;

namespace Railway.Services
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
        void SaveCar();
    }

    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;
        private readonly ICarTypeRepository carTypeRepository;
        private readonly IUnitOfWork unitOfWork;

        public CarService(ICarRepository carRepository, ICarTypeRepository carTypeRepository, IUnitOfWork unitOfWork)
        {
            this.carRepository = carRepository;
            this.carTypeRepository = carTypeRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Car> GetAllCars()
        {
            var cars = carRepository.GetAll();

            return cars;
        }

        public void SaveCar()
        {
            unitOfWork.Commit();
        }
    }
}
