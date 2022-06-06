using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Clients.Service;
using WickedTunaAPI.Cottages.Exceptions;
using WickedTunaAPI.Cottages.Repositroies;
using WickedTunaAPI.Cottages.Repositroy;
using WickedTunaCore.Cottages;

namespace WickedTunaAPI.Cottages.Service
{
    public class CottageService : ICottageService
    {
        private readonly ICottageRepository _cottageRepositroy;
        private readonly ICottageAvailablePeriodRepositroy _cottageAvailablePeriodRepositroy;
        private readonly ICottageReservationRepositroy _cottageReservationRepositroy;
        private readonly IClientService _clientService;

        public CottageService(ICottageRepository cottageRepositroy, ICottageAvailablePeriodRepositroy cottageAvailablePeriodRepositroy, ICottageReservationRepositroy cottageReservationRepositroy, IClientService clientService)
        {
            _cottageRepositroy = cottageRepositroy;
            _cottageAvailablePeriodRepositroy = cottageAvailablePeriodRepositroy;
            _cottageReservationRepositroy = cottageReservationRepositroy;
            _clientService = clientService;
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

        public Cottage GetCottageForId(Guid id)
        {
            return _cottageRepositroy.GetById(id);
        }

        public List<string> GetImagesForCottage(Guid id)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Data", "Cottages", id.ToString());
            var directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles().Select(o => o.Name).ToList();
        }

        public byte[] GetCottageImageForId(Guid cottageId, string name)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Data", "Cottages", cottageId.ToString(), name);
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            return null;
        }

        public byte[] GetFirstImageForCottage(Guid id)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Data", "Cottages", id.ToString());
            var directoryInfo = new DirectoryInfo(path);
            var imagePath = directoryInfo.GetFiles().First();
            return File.ReadAllBytes(imagePath.FullName);
        }

        public CottageReservation CreateNewReservation(Guid id, CottageReservation cottageReservation, string email)
        {
            var cottage = _cottageRepositroy.GetById(id);
            if(cottage == null)
            {
                throw new CottageNotFoundException();
            }
            var period = _cottageAvailablePeriodRepositroy.GetForReservation(id, cottageReservation.Start, cottageReservation.End);
            if(period == null)
            {
                throw new PeriodNotFoundExcetpion();
            }
            var period1 = new CottageAvailablePeriod()
            {
                Cottage = cottage,
                Start = period.Start,
                End = cottageReservation.Start,
            };
            var period2 = new CottageAvailablePeriod()
            {
                Cottage = cottage,
                Start = cottageReservation.End,
                End = period.End,
            };
            _cottageAvailablePeriodRepositroy.Insert(period1);
            _cottageAvailablePeriodRepositroy.Insert(period2);
            _cottageAvailablePeriodRepositroy.Remove(period);
            _cottageAvailablePeriodRepositroy.Save();

            cottageReservation.Cottage = cottage;
            cottageReservation.Price = cottage.Price;
            var client = _clientService.GetClientForEmail(email);
            cottageReservation.Client = client;
            _cottageReservationRepositroy.Insert(cottageReservation);
            _cottageReservationRepositroy.Save();
            return cottageReservation;

        }

        public List<CottageReservation> GetCottageSpecialOffers()
        {
            return _cottageReservationRepositroy.GetWithoutClient();
        }

        public CottageReservation ConfirmSpecialOffer(Guid id, CottageReservation cottageReservation, string email)
        {
            var specialOffer = _cottageReservationRepositroy.GetById(id);
            if(specialOffer == null)
            {
                return null;
            }
            var client = _clientService.GetClientForEmail(email);
            if(client == null)
            {
                return null;
            }
            specialOffer.Client = client;
            _cottageReservationRepositroy.Save();
            return specialOffer;
        }
    }
}
