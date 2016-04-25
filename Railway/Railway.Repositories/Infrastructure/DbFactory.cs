using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.Repositories.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private RailwayContext dbContext;

        public RailwayContext Init()
        {
            return dbContext ?? (dbContext = new RailwayContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
