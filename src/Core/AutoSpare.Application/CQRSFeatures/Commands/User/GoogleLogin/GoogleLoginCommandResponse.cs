using AutoSpare.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.User.GoogleLogin
{
    public class GoogleLoginCommandResponse
    {
        public Token Token {  get; set; }
    }
}
