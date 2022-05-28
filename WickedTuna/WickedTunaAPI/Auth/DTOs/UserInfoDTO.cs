﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WickedTunaAPI.Auth.DTOs
{
    public class UserInfoDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
