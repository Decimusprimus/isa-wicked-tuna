using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Users;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.SystemAdmins.Repositories
{
    public class SystemAdminRepository : Repository<SystemAdmin>, ISystemAdminRepositroy
    {
        public SystemAdminRepository(WickedTunaDbContext context) : base(context)
        {
        }
    }
}
