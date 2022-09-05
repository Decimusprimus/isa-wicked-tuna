using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedTunaAPI.SystemAdmins.Services;

namespace WickedTunaAPI.SystemAdmins.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class SystemAdminController : ControllerBase
    {
        private readonly ISystemAdminService _systemAdminService;

        public SystemAdminController(ISystemAdminService systemAdminService)
        {
            _systemAdminService = systemAdminService;
        }


    }
}
