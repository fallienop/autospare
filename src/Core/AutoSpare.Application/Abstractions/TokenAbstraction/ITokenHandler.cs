using AutoSpare.Application.DTOs;
using AutoSpare.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.Abstractions.TokenAbstraction
{
    public interface ITokenHandler
    {
       Task<Token> CreateAccessToken(AppUser user);
        string CreateRefreshToken();
    }
}
