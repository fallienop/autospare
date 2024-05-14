using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Users.ChangeUserPassword
{
    public class ChangeUserPasswordCommandRequest : IRequest<ChangeUserPasswordCommandResponse>
    {
        public string UserName { get; set; }
        public string OldPassword {  get; set; }
        public string NewPassword { get; set; }
    }
}
