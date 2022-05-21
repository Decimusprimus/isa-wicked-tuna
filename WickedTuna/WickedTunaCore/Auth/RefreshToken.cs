using System;
using System.ComponentModel.DataAnnotations;

namespace WickedTunaCore.Auth
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }

        public string Token { get; set; }
        public DateTime ExpiryOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime RevokedOn { get; set; }
        public string RevokedByIp { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
