﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WickedTunaAPI.DTOs
{
    public class RegistrationForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordRepeated { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string StreetNubmer { get; set; }
    }
}
