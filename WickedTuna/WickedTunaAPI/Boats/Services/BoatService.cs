using System;
using System.Collections.Generic;
using System.IO;
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
    }
}
