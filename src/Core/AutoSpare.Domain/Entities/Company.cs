using AutoSpare.Domain.Entities.Common;
using AutoSpare.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSpare.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<AppUser>? AppUsers { get; set; }


        public byte[]? Image { get; set; }

    }
}
