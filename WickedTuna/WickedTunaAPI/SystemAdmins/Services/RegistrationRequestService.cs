using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaAPI.SystemAdmins.Repositories;
using WickedTunaCore.Auth;

namespace WickedTunaAPI.SystemAdmins.Services
{
    public class RegistrationRequestService : IRegistrationRequestService
    {
        private readonly IRegistrationRequestRepositroy _registrationRequestRepositroy;

        public RegistrationRequestService(IRegistrationRequestRepositroy registrationRequestRepositroy)
        {
            _registrationRequestRepositroy = registrationRequestRepositroy;
        }

        public void CreateRegistrationRequest(UserRegistrationForm userRegistrationForm)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest
            {
                Email = userRegistrationForm.Email,
                Password = userRegistrationForm.Password,
                Name = userRegistrationForm.Name,
                Surname = userRegistrationForm.Surname,
                PhoneNumber = userRegistrationForm.PhoneNumber,
                County = userRegistrationForm.Country,
                City = userRegistrationForm.City,
                StreetName = userRegistrationForm.StreetName,
                Explanation = userRegistrationForm.Explanation,
                Role = userRegistrationForm.Role,
                Status = false,
                Reviewed = false
            };
            _registrationRequestRepositroy.Insert(registrationRequest);
            _registrationRequestRepositroy.Save();
        }

        public List<RegistrationRequest> GetRequestToReview()
        {
            return _registrationRequestRepositroy.GetRequestToReveiw();
        }
    }
}
