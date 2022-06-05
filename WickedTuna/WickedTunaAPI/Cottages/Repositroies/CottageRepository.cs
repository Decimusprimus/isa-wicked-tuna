using Microsoft.EntityFrameworkCore;
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

        public List<Cottage> GetAvailable()
        {
            var res =  _context.Cottages.Where(c => c.CottageAvailablePeriods.Any(cap => cap.Start < DateTime.Now || cap.End > DateTime.Now)).Include(c => c.CottageAvailablePeriods);
            return res.ToList();
        }

        public Cottage GetById(Guid id)
        {
            return _context.Cottages.Include(c => c.CottageAvailablePeriods).FirstOrDefault(c => c.Id == id);
        }
    }
}
