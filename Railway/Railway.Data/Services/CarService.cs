using System.Collections.Generic;
using System.Linq;
using Railway.Data.Models;

namespace Railway.Data.Services
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
    }

    public class CarService : ICarService
    {
        private readonly RailwayContext context;

        public CarService(RailwayContext context)
        {
            this.context = context;
        }

        public IEnumerable<Car> GetAllCars()
        {
            var cars = context.Cars.ToList();

            return cars;
        }
    }
}
