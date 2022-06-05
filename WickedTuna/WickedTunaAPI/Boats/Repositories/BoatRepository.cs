using Microsoft.EntityFrameworkCore;
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

        public Boat GetById(Guid id)
        {
            return _context.Boats.Include(b => b.BoatAvailablePeriods).Include(b => b.BoatAdditionalOptions).FirstOrDefault(b => b.Id == id);
        }
    }
}
