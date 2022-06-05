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
        Boat GetBoatForId(Guid id);
        List<string> GetImagesForBoat(Guid id);
        Byte[] GetBoatImageForId(Guid boatId, string name);
        Byte[] GetFirstImageForBoat(Guid id);
    }
}
