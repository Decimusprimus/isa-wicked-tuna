using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaCore.Auth;

namespace WickedTunaAPI.SystemAdmin.Services
{
    public interface IRegistrationRequestService
    {
        void CreateRegistrationRequest(UserRegistrationForm userRegistrationForm);
        List<RegistrationRequest> GetRequestToReview();
    }
}
