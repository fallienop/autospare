using AutoSpare.Application.DTOs.User;
using AutoSpare.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<List<UserList>> GetAllUsers(int page,int size);   
        Task UpdateRefreshToken(string refreshToken,AppUser user, DateTime accessTokenDate);
    }
}
