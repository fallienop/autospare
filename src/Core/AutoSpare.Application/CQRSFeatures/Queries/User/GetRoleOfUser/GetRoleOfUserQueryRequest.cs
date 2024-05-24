using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.User.GetRoleOfUser
{
    public class GetRoleOfUserQueryRequest : IRequest<GetRoleOfUserQueryResponse>
    {
        public string Id { get; set; }
    }
}
