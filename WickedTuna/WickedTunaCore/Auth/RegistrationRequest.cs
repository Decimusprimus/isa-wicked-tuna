using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WickedTunaCore.Auth
{
    public class RegistrationRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string StreetNubmer { get; set; }
        public string Explanation { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        public bool Reviewed { get; set; }
    }
}
