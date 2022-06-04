using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaCore.Boats;

namespace WickedTunaAPI.Boats.Services
{
    public interface IBoatService
    {
        List<Boat> GetAllBoats();
    }
}
