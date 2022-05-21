using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.Auth.DTOs;
using WickedTunaCore.Auth;

namespace WickedTunaAPI.Auth.Service
{
    public interface IUserService
    {
        Task<ApplicationUser> ValidateUserLoginCredentials(LoginCredentials loginCredentials);
    }
}
