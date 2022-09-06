using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Boats.Exceptions;
using WickedTunaAPI.Boats.Repositories;
using WickedTunaAPI.Clients.Service;
using WickedTunaAPI.Cottages.Exceptions;
using WickedTunaCore.Boats;
using WickedTunaCore.Common;

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
                throw new BoatNotFoundException();
            }

            var client = _clientService.GetClientForEmail(email);
            var existingReservation = _boatReservationRepositroy.CheckReservationForClient(client.UserId, boatReservation.Start, boatReservation.End);
            if (existingReservation != null)
            {
                throw new BoatReservationException();
            }
            BoatAvailablePeriod period1 = null;
            var period = _boatAvailablePeriodRepository.GetPeriodForReservation(id, boatReservation.Start, boatReservation.End);
            if(period == null)
            {
                throw new PeriodNotFoundExcetpion();
            }

            if (period.Start == boatReservation.Start && period.End == boatReservation.End)
            {
                _boatAvailablePeriodRepository.Remove(period);
            }
            else if (period.Start == boatReservation.Start)
            {
                period.Start = boatReservation.End;
            }
            else if (period.End == boatReservation.End)
            {
                period.End = boatReservation.Start;
            }
            else
            {
                period1 = new BoatAvailablePeriod()
                {
                    Boat = boat,
                    Start = period.Start,
                    End = boatReservation.Start,
                };
                period.Start = boatReservation.End;
                
            }

            var saved = false;
            var alreadyReserved = false;
            while (!saved)
            {
                try
                {
                    _boatAvailablePeriodRepository.Save();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is BoatAvailablePeriod)
                        {
                            var databaseValues = entry.GetDatabaseValues();

                            entry.OriginalValues.SetValues(databaseValues);
                            alreadyReserved = true;
                        }
                        else
                        {
                            throw new NotSupportedException();
                        }
                    }
                }
            }
            if (alreadyReserved)
            {
                return null;
            }
            

            if(period1 != null)
            {
                _boatAvailablePeriodRepository.Insert(period1);
            }

            boatReservation.Boat = boat;
            boatReservation.ReservationStatus = ReservationStatus.Acite;
            boatReservation.ReservationType = ReservationType.Reservation;
            var optionsSum = 0f;
            foreach(var item in boatReservation.BoatReservationOptions)
            {
                item.Id = Guid.NewGuid();
                optionsSum += item.Price;
            }
            boatReservation.Price = boat.Price + optionsSum;
            
            boatReservation.Client = client;
            _boatReservationRepositroy.Insert(boatReservation);
            _boatReservationRepositroy.Save();
            return boatReservation;

        }

        public List<BoatReservation> GetBoatSpecialOffers()
        {
            return _boatReservationRepositroy.GetWithoutClient();
        }

        public BoatReservation ConfirmSpecialOffer(Guid id, BoatReservation boatReservation, string email)
        {
            var specialOffer = _boatReservationRepositroy.GetById(id);
            if (specialOffer == null)
            {
                throw new Exception();
            }
            var client = _clientService.GetClientForEmail(email);
            if (client == null)
            {
                throw new Exception();
            }

            var existingReservation = _boatReservationRepositroy.CheckReservationForClient(client.UserId, boatReservation.Start, boatReservation.End);
            if (existingReservation != null)
            {
                throw new BoatReservationException();
            }

            specialOffer.Client = client;
            specialOffer.ReservationStatus = ReservationStatus.Acite;

            var saved = false;
            var alreadyReserved = false;
            while (!saved)
            {
                try
                {
                    _boatReservationRepositroy.Save();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is BoatReservation)
                        {
                            var databaseValues = entry.GetDatabaseValues();

                            entry.OriginalValues.SetValues(databaseValues);
                            alreadyReserved = true;
                        }
                        else
                        {
                            throw new NotSupportedException();
                        }
                    }
                }
            }
            if (alreadyReserved)
            {
                return null;
            }

            
            return specialOffer;
        }

        public List<BoatReservation> GetActiveReservations(string email)
        {
            var client = _clientService.GetClientForEmail(email);
            if (client == null)
            {
                return null;
            }
            return _boatReservationRepositroy.GetActiveReservationsForClient(client.UserId);
        }

        public List<BoatReservation> GetPastReservations(string email)
        {
            var client = _clientService.GetClientForEmail(email);
            if (client == null)
            {
                return null;
            }
            return _boatReservationRepositroy.GetPastReservationsForClient(client.UserId);
        }

        public bool CancelReservation(Guid id, BoatReservation boatReservation, string email)
        {
            var reservation = _boatReservationRepositroy.GetById(id);
            if (reservation != null && reservation.Start < DateTime.Now.AddDays(3))
            {
                throw new BoatReservationException();
            }

            var client = _clientService.GetClientForEmail(email);
            if (String.Equals(reservation.ClientId, client.UserId))
            {
                if (reservation.ReservationType == ReservationType.Special_offer)
                {
                    var specialOffer = new BoatReservation()
                    {
                        Start = reservation.Start,
                        End = reservation.End,
                        ReservationType = ReservationType.Special_offer,
                        ClientId = null,
                        Price = reservation.Price,
                        NumberOfPeople = reservation.NumberOfPeople,
                        BoatId = reservation.BoatId,
                        ReservationStatus = ReservationStatus.Acite
                    };
                    specialOffer.BoatReservationOptions = new List<BoatReservationOptions>();
                    foreach(var item in reservation.BoatReservationOptions)
                    {
                        specialOffer.BoatReservationOptions.Add(new BoatReservationOptions()
                        {
                            Description = item.Description,
                            Price = item.Price,
                            BoatReservation = specialOffer,
                        });
                    }
                    reservation.ReservationStatus = ReservationStatus.Cancelled;
                    _boatReservationRepositroy.Insert(specialOffer);
                    _boatReservationRepositroy.Save();
                }
                else
                {
                    var starPeriod = _boatAvailablePeriodRepository.GetPeriodStartWhenCancelling(reservation.BoatId, reservation.End);
                    var endperiod = _boatAvailablePeriodRepository.GetPeriodEndWhenCancelling(reservation.BoatId, reservation.Start);
                    if (starPeriod != null && endperiod != null)
                    {
                        endperiod.End = starPeriod.End;
                        _boatAvailablePeriodRepository.Remove(starPeriod);
                    }
                    else if (starPeriod != null)
                    {
                        starPeriod.Start = reservation.Start;
                    }
                    else if (endperiod != null)
                    {
                        endperiod.End = reservation.End;
                    }
                    else
                    {
                        var period = new BoatAvailablePeriod()
                        {
                            Start = reservation.Start,
                            End = reservation.End,
                            BoatId = reservation.BoatId,
                        };
                        _boatAvailablePeriodRepository.Insert(period);
                    }
                    reservation.ReservationStatus = ReservationStatus.Cancelled;
                    _boatReservationRepositroy.Save();
                    _boatAvailablePeriodRepository.Save();
                }
                return true;
            }
            return false;
        }
    }
}
