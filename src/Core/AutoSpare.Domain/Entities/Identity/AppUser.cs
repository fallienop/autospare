using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoSpare.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string NameSurname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
        public ICollection<Order>? Orders { get; set; }
        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }


        public byte[]? ProfilePhoto { get; set; }
    }
}
