using WickedTunaCore.Users;
using WickedTunaAPI.DTOs;

namespace WickedTunaAPI.Clients.Service
{
    public interface IClientService
    {
        bool CreateNewUserAsClient(ClientRegistrationForm registrationForm, string userId);
    }
}
