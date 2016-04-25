using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway.Models.Models;
using Railway.Repositories.Infrastructure;

namespace Railway.Repositories.Repositories
{
    public interface ICarTypeRepository : IRepository<CarType>
    {
        CarType GetCarTypeByName(string carTypeName);
    }

    public class CarTypeRepository : RepositoryBase<CarType>, ICarTypeRepository
    {
        public CarTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public CarType GetCarTypeByName(string carTypeName)
        {
            var carType = this.DbContext.CarTypes.FirstOrDefault(c => c.TypeName == carTypeName);

            return carType;
        }
    }
}
