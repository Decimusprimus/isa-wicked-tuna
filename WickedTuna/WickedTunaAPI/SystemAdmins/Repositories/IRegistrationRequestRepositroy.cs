using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.util;
using WickedTunaCore.Auth;

namespace WickedTunaAPI.SystemAdmins.Repositories
{
    public interface IRegistrationRequestRepositroy : IRepository<RegistrationRequest>
    {
        List<RegistrationRequest> GetRequestToReveiw();
    }
}
