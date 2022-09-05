using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Auth;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.SystemAdmin.Repositories
{
    public class RegistrationRequestRepositroy : Repository<RegistrationRequest>, IRegistrationRequestRepositroy
    {
        public RegistrationRequestRepositroy(WickedTunaDbContext context) : base(context)
        {
        }

        public List<RegistrationRequest> GetRequestToReveiw()
        {
            return _context.RegistrationRequests.Where(r => r.Reviewed == false).ToList();
        }
    }
}
