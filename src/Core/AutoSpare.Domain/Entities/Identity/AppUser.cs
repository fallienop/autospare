using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities.Identity
{
        public class AppUser : IdentityUser<string>
        {
            public string NameSurname {  get; set; }
            public string? RefreshToken { get; set; }
            public DateTime? RefreshTokenExpiration {  get; set; }
            public List<Order>? Orders { get; set; }
        }
}
