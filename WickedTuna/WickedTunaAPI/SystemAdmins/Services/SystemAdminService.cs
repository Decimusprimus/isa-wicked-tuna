using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.SystemAdmins.Repositories;

namespace WickedTunaAPI.SystemAdmins.Services
{
    public class SystemAdminService : ISystemAdminService
    {
        private readonly ISystemAdminRepositroy _systemAdminRepositroy;

        public SystemAdminService(ISystemAdminRepositroy systemAdminRepositroy)
        {
            _systemAdminRepositroy = systemAdminRepositroy;
        }


    }
}
