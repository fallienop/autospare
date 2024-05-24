using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Users.AddRoleToUser
{
    public class AddRoleToUserCommandRequest : IRequest<AddRoleToUserCommandResponse>
    {
        public string UserId { get; set; }
        public Guid CompanyId { get; set; }

    }
}
