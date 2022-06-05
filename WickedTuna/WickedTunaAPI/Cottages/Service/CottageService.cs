using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Cottages.Repositroy;
using WickedTunaCore.Cottages;

namespace WickedTunaAPI.Cottages.Service
{
    public class CottageService : ICottageService
    {
        private readonly ICottageRepository _cottageRepositroy;

        public CottageService(ICottageRepository cottageRepositroy)
        {
            _cottageRepositroy = cottageRepositroy;
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
    }
}
