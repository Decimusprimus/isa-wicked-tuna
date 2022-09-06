using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Clients.Service;
using WickedTunaAPI.Cottages.Exceptions;
using WickedTunaAPI.Cottages.Repositroies;
using WickedTunaAPI.Cottages.Repositroy;
using WickedTunaCore.Common;
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

            if(period.Start == cottageReservation.Start && period.End == cottageReservation.End)
            {
                _cottageAvailablePeriodRepositroy.Remove(period);
            }
            else if(period.Start == cottageReservation.Start)
            {
                period.Start = cottageReservation.End;
            }
            else if(period.End == cottageReservation.End)
            {
                period.End = cottageReservation.Start;
            }
            else 
            {
                var period1 = new CottageAvailablePeriod()
                {
                    Cottage = cottage,
                    Start = period.Start,
                    End = cottageReservation.Start,
                };
                period.Start = cottageReservation.End;
                _cottageAvailablePeriodRepositroy.Insert(period1);
            }
            _cottageAvailablePeriodRepositroy.Save();

            cottageReservation.Cottage = cottage;
            cottageReservation.Price = cottage.Price;
            cottageReservation.ReservationType = ReservationType.Reservation;
            cottageReservation.ReservationStatus = ReservationStatus.Acite;
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
            specialOffer.ReservationStatus = ReservationStatus.Acite;
            _cottageReservationRepositroy.Save();
            return specialOffer;
        }

        public List<CottageReservation> GetActiveReservations(string email)
        {
            var client = _clientService.GetClientForEmail(email);
            if(client == null)
            {
                return null;
            }
            return _cottageReservationRepositroy.GetActiveReservationsForClient(client.UserId);
        }

        public List<CottageReservation> GetPastReservations(string email)
        {
            var client = _clientService.GetClientForEmail(email);
            if (client == null)
            {
                return null;
            }
            return _cottageReservationRepositroy.GetPastReservationsForClient(client.UserId);
        }

        public bool CancelReservation(Guid id, CottageReservation cottageReservation, string email)
        {
            var reservation = _cottageReservationRepositroy.GetById(id);
            if (reservation != null && reservation.Start < DateTime.Now.AddDays(3))
            {
                throw new CottageReservationException();
            }
            var client = _clientService.GetClientForEmail(email);
            if (String.Equals(reservation.ClientId, client.UserId))
            {
                if (reservation.ReservationType == ReservationType.Special_offer)
                {
                    reservation.Client = null;
                    reservation.ReservationStatus = ReservationStatus.Cancelled;
                    _cottageReservationRepositroy.Save();
                }
                else
                {
                    var starPeriod = _cottageAvailablePeriodRepositroy.GetPeriodStartWhenCancelling(reservation.CottageId, reservation.End);
                    var endperiod = _cottageAvailablePeriodRepositroy.GetPeriodEndWhenCancelling(reservation.CottageId, reservation.Start);
                    if (starPeriod != null && endperiod != null)
                    {
                        endperiod.End = starPeriod.End;
                        _cottageAvailablePeriodRepositroy.Remove(starPeriod);
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
                        var period = new CottageAvailablePeriod()
                        {
                            Start = reservation.Start,
                            End = reservation.End,
                            CottageId = reservation.CottageId,
                        };
                        _cottageAvailablePeriodRepositroy.Insert(period);
                    }
                    reservation.ReservationStatus = ReservationStatus.Cancelled;
                    _cottageReservationRepositroy.Save();
                    _cottageAvailablePeriodRepositroy.Save();

                }
                return true;
            }
            return false;

            /* if(reservation != null && reservation.Start > DateTime.Now.AddDays(3))
             {
                 var client = _clientService.GetClientForEmail(email);
                 if(String.Equals(reservation.ClientId,client.UserId))
                 {
                     if(reservation.ReservationType == ReservationType.Special_offer)
                     {
                         reservation.Client = null;
                         reservation.ReservationStatus = ReservationStatus.Cancelled;
                         _cottageReservationRepositroy.Save();
                     }
                     else
                     {
                         var starPeriod = _cottageAvailablePeriodRepositroy.GetPeriodStartWhenCancelling(reservation.CottageId, reservation.End);
                         var endperiod = _cottageAvailablePeriodRepositroy.GetPeriodEndWhenCancelling(reservation.CottageId, reservation.Start);
                         if(starPeriod != null && endperiod != null)
                         {
                             endperiod.End = starPeriod.End;
                             _cottageAvailablePeriodRepositroy.Remove(starPeriod);
                         }
                         else if(starPeriod != null)
                         {
                             starPeriod.Start = reservation.Start;
                         }
                         else if(endperiod != null)
                         {
                             endperiod.End = reservation.End;
                         }
                         else
                         {
                             var period = new CottageAvailablePeriod()
                             {
                                 Start = reservation.Start,
                                 End = reservation.End,
                                 CottageId = reservation.CottageId,
                             };
                             _cottageAvailablePeriodRepositroy.Insert(period);
                         }
                         reservation.ReservationStatus = ReservationStatus.Cancelled;
                         _cottageReservationRepositroy.Save();
                         _cottageAvailablePeriodRepositroy.Save();

                     }
                     return true;
                 }
             }
             return false;
             */
        }


        
    }
}
