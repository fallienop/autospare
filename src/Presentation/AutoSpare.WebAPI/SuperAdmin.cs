using AutoSpare.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace AutoSpare.WebAPI
{
    
    public class SuperAdmin
    {
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<AppRole> _roleManager;

        public SuperAdmin(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AddSuperAdmin()
        {
            if(!_userManager.Users.Any())
            {
                var user1 = new AppUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "asparesuperadmin@gmail.com",
                    UserName = "asparesuperadmin",
                    NameSurname = "Aspare Admin"

                };
                var user2 = new AppUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "faliens1@gmail.com",
                    UserName = "fallienss",
                    NameSurname = "fallien ss"

                };
                var resp1 = await _userManager.CreateAsync(user1, "aspareSuperAdmin1234");
                var resp2 = await _userManager.CreateAsync(user2, "fallien1");

                var user11 = await _userManager.FindByNameAsync("asparesuperadmin");
                var user12 = await _userManager.FindByNameAsync("fallienss");
                await _roleManager.CreateAsync(new AppRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "admin"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "superadmin"
                });

                var resp11 = await _userManager.AddToRoleAsync(user11, "superadmin");
                var resp22 = await _userManager.AddToRoleAsync(user12, "admin");
                Console.WriteLine(resp11.Errors);
                Console.WriteLine(resp22.Errors);
                Console.WriteLine(1);
            }
                //Console.WriteLine(0);


        }
    }
}
