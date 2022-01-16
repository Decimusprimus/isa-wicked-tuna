using System;
using WickedTunaCore.Auth;
using WickedTunaCore.Common;

namespace WickedTunaCore.Users
{
    public abstract class TUser
    {
        public string UserId { get; set; }
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

        public ApplicationUser ApplicationUser { get; set; }
    }
}
