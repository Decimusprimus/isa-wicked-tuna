using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Cottages;

namespace WickedTunaAPI.Cottages.Repositroy
{
    public interface ICottageRepository : IRepository<Cottage>
    {
        List<Cottage> GetAvailable();
        Cottage GetById(Guid id);
    }
}
