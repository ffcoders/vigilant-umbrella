using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vigilant_umbrella_infrastructure.Context;

namespace vigilant_umbrella_infrastructure.UnitOfWork
{
    public class VigilantUmbrellaUow : IBaseUnitOfWork
    {
        private IVigilantUmbrellaDbContext vigilantUmbrellaDbContext;

        public VigilantUmbrellaUow(IVigilantUmbrellaDbContext vigilantUmbrellaDbContext)
        {
            this.vigilantUmbrellaDbContext = vigilantUmbrellaDbContext;
        }

        public Task DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
