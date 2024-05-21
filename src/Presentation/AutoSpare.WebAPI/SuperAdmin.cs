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
            //var user = new AppUser()
            //{
            //    Id=Guid.NewGuid().ToString(),
            //    Email = "asparesuperadmin@gmail.com",
            //    UserName = "asparesuperadmin",
            //    NameSurname = "Aspare Admin"

            //};
            //var resp =  await _userManager.CreateAsync(user, "aspareSuper548");

            var user = await _userManager.FindByNameAsync("asparesuperadmin");
           //await _roleManager.CreateAsync(new AppRole()
           // {
           //    Id= Guid.NewGuid().ToString(),
           //     Name = "Superadmin"
           // });

           var resp= await _userManager.AddToRoleAsync(user, "Superadmin");
            Console.WriteLine(resp.Errors);

        }
    }
}
