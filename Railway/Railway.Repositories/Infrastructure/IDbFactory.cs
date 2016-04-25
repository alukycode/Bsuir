using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Repositories.Infrastructure
{
    // todo: нахуй нам эта фабрика?
    public interface IDbFactory : IDisposable
    {
        RailwayContext Init();
    }
}
