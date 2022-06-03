using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Cottages.Repositroy;
using WickedTunaCore.Cottages;

namespace WickedTunaAPI.Cottages.Service
{
    public class CottageService : ICottageService
    {
        private readonly ICottageRepository _cottageRepositroy;

        public CottageService(ICottageRepository cottageRepositroy)
        {
            _cottageRepositroy = cottageRepositroy;
        }

        public List<Cottage> GetAll()
        {
            return _cottageRepositroy.GetAll().ToList();
        }

        public List<Cottage> GetAvailable()
        {
            var res = _cottageRepositroy.GetAvailable();
            return res;
        }
    }
}
