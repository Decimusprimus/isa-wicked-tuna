using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Boats.Repositories;
using WickedTunaCore.Boats;

namespace WickedTunaAPI.Boats.Services
{
    public class BoatService :  IBoatService
    {
        private readonly IBoatRepository _boatRepository;

        public BoatService(IBoatRepository boatRepository)
        {
            _boatRepository = boatRepository;
        }

        public List<Boat> GetAllBoats()
        {
            return _boatRepository.GetAll().ToList();
        }

        public Boat GetBoatForId(Guid id)
        {
            return _boatRepository.GetById(id);
        }
    }
}
