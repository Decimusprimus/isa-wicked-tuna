﻿using System;
using WickedTunaCore.Common;

namespace WickedTunaCore.Users
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string StreetNubmer { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
