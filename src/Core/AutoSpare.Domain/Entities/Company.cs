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
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string WorkStart { get; set; }
        public string WorkEnd { get; set; }

    }
}
