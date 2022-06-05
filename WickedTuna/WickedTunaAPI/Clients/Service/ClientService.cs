using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.DTOs;
using WickedTunaCore.Users;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.Clients.Service
{
    public class ClientService : IClientService
    {
        private readonly WickedTunaDbContext _dbContext;

        public ClientService(WickedTunaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateNewUserAsClient(ClientRegistrationForm registrationForm, string userId)
        {
            var client = new Client()
            {
                UserId = userId,
                Email = registrationForm.Email,
                Name = registrationForm.Name,
                Surname = registrationForm.Surname,
                PhoneNumber = registrationForm.PhoneNumber,
                County = registrationForm.Country,
                City = registrationForm.City,
                StreetName = registrationForm.StreetName,
                IsActive = true
            };

            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();

            return true;

        }

        public Client GetClientForEmail(string email)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.Email == email);
        }
    }
}
