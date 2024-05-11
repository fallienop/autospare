using AutoSpare.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.Abstractions.Services
{
    public interface IGoogleLogin
    {
        public Task<Token> TokenViaGoogleAsync(string idToken, string provider);
    }
}
