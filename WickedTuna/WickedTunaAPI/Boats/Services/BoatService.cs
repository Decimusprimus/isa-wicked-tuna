using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Boats.Repositories;
using WickedTunaAPI.Clients.Service;
using WickedTunaCore.Boats;

namespace WickedTunaAPI.Boats.Services
{
    public class BoatService :  IBoatService
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IBoatAvailablePeriodRepository _boatAvailablePeriodRepository;
        private readonly IBoatReservationRepositroy _boatReservationRepositroy;
        private readonly IClientService _clientService;

        public BoatService(IBoatRepository boatRepository, IBoatAvailablePeriodRepository boatAvailablePeriodRepository, IBoatReservationRepositroy boatReservationRepositroy, IClientService clientService)
        {
            _boatRepository = boatRepository;
            _boatAvailablePeriodRepository = boatAvailablePeriodRepository;
            _boatReservationRepositroy = boatReservationRepositroy;
            _clientService = clientService;
        }

        public List<Boat> GetAllBoats()
        {
            return _boatRepository.GetAll().ToList();
        }

        public Boat GetBoatForId(Guid id)
        {
            return _boatRepository.GetById(id);
        }

        public List<string> GetImagesForBoat(Guid id)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Data", "Boats", id.ToString());
            var directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles().Select(o => o.Name).ToList();
        }

        public byte[] GetBoatImageForId(Guid boatId, string name)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Data", "Boats", boatId.ToString(), name);
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            return null;
        }

        public byte[] GetFirstImageForBoat(Guid id)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Data", "Boats", id.ToString());
            var directoryInfo = new DirectoryInfo(path);
            var imagePath = directoryInfo.GetFiles().First();
            return File.ReadAllBytes(imagePath.FullName);
        }

        public BoatReservation CreateNewReservation(Guid id, BoatReservation boatReservation, string email)
        {
            var boat = _boatRepository.GetById(id);
            if(boat == null)
            {
                return null;
            }
            var period = _boatAvailablePeriodRepository.GetPeriodForReservation(id, boatReservation.Start, boatReservation.End);
            if(period == null)
            {
                return null;
            }
            var period1 = new BoatAvailablePeriod()
            {
                Boat = boat,
                Start = boatReservation.End,
                End = period.End,
            };
            period.End = boatReservation.Start;
            _boatAvailablePeriodRepository.Insert(period1);
            _boatAvailablePeriodRepository.Save();

            boatReservation.Boat = boat;
            var optionsSum = 0f;
            foreach(var item in boatReservation.BoatReservationOptions)
            {
                optionsSum += item.Price;
            }
            boatReservation.Price = boat.Price + optionsSum;
            var client = _clientService.GetClientForEmail(email);
            boatReservation.Client = client;
            _boatReservationRepositroy.Insert(boatReservation);
            _boatReservationRepositroy.Save();
            return boatReservation;

        }

        public List<BoatReservation> GetBoatSpecialOffers()
        {
            return _boatReservationRepositroy.GetWithoutClient();
        }
    }
}
