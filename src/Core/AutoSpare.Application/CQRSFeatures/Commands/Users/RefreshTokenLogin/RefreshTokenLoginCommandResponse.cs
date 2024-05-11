using AutoSpare.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Users.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse
    {
        public Token Token { get; set; }
    }
}
