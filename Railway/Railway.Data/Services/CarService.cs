using System.Collections.Generic;
using System.Linq;
using Railway.Data.Entities;

namespace Railway.Data.Services
{
    public class CarService
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
