using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.User.GetRoleOfUser
{
    public class GetRoleOfUserQueryResponse
    {
        public IList<string>? Role { get; set; }
        public Guid? CompanyId {  get; set; }  
    }
}
