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
        List<Cottage> GetAvailable();
        Cottage GetCottageForId(Guid id);
        List<string> GetImagesForCottage(Guid id);
        Byte[] GetCottageImageForId(Guid cottageId,string name);
        Byte[] GetFirstImageForCottage(Guid id);
        CottageReservation CreateNewReservation(Guid id, CottageReservation cottageReservation, string email);
        List<CottageReservation> GetCottageSpecialOffers();
        CottageReservation ConfirmSpecialOffer(Guid id, CottageReservation cottageReservation, string email);

    }
}
