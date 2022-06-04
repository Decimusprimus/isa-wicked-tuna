using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Boats;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Boats.Repositories
{
    public class BoatRepository : Repository<Boat>, IBoatRepository
    {
        public BoatRepository(WickedTunaDbContext context) : base(context)
        {
        }
    }
}
