using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Cottages;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Cottages.Repositroies
{
    public class CottageAvailablePeriodRepository : Repository<CottageAvailablePeriod>, ICottageAvailablePeriodRepositroy
    {
        public CottageAvailablePeriodRepository(WickedTunaDbContext context) : base(context)
        {
        }
    }
}
