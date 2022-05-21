using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WickedTunaAPI.Auth.DTOs
{
    public class LoginCredentials
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string IpAddress { get; set; }
    }
}
