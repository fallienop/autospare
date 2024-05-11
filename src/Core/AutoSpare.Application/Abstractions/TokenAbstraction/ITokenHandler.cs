using AutoSpare.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.Abstractions.TokenAbstraction
{
    public interface ITokenHandler
    {
        Token CreateAccessToken();
        string CreateRefreshToken();
    }
}
