using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway.Models.Models;

namespace Railway.Repositories
{
    public class RailwaySeedData : DropCreateDatabaseIfModelChanges<RailwayContext>
    {
        protected override void Seed(RailwayContext context)
        {
            context.CarTypes.AddRange(GetCarTypes());
            context.Commit();

            context.Cars.AddRange(GetCars());
            context.Commit();
        }

        private static List<Car> GetCars()
        {
            return new List<Car>
            {
                new Car
                {
                    CarIndex = 1,
                    CarTypeId = 1,
                },
                new Car
                {
                    CarIndex = 2,
                    CarTypeId = 2,
                }
            };
        }

        private static List<CarType> GetCarTypes()
        {
            return new List<CarType>
            {
                new CarType
                {
                    CostRate = 1,
                    SeatCount = 90,
                    TypeName = "Общий"
                },
                new CarType
                {
                    CostRate = 1.35,
                    SeatCount = 60,
                    TypeName = "Плацкарт"
                }
            };
        }
    }
}
