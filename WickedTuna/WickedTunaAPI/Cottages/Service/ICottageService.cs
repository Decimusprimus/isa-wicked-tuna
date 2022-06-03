using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaCore.Cottages;

namespace WickedTunaAPI.Cottages.Service
{
    public interface ICottageService
    {
        List<Cottage> GetAll();
    }
}
