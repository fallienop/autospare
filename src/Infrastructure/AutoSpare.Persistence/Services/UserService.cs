
using AutoSpare.Application.Abstractions.Services;
using AutoSpare.Application.DTOs.User;
using AutoSpare.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<List<UserList>> GetAllUsers(int page, int size)
        {
          var users = await _userManager.Users.Skip(page*size).Take(size).ToListAsync();
            return users.Select(user => new UserList
            {
                Id = user.Id,
                Email = user.Email,
                NameSurname = user.NameSurname,
                UserName = user.UserName

            }).ToList();
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiration = accessTokenDate.AddMinutes(int.Parse(_configuration["Token:RefreshTokenExpiration"]));
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

     
    }
}
