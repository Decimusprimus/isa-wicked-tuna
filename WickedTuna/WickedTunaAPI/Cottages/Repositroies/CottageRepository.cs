using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Cottages.Repositroy;
using WickedTunaAPI.util;
using WickedTunaCore.Cottages;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Cottages.Repositroies
{
    public class CottageRepository : Repository<Cottage>, ICottageRepository
    {
        public CottageRepository(WickedTunaDbContext context) : base(context)
        {
        }
    }
}
