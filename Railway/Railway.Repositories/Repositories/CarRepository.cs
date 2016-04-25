using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Railway.Models.Models;
using Railway.Repositories.Infrastructure;

namespace Railway.Repositories.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
    }

    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}
