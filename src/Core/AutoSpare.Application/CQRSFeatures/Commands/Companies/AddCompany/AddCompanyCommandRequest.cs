using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Companies.AddCompany
{
    public class AddCompanyCommandRequest : IRequest<AddCompanyCommandResponse>
    {
        public string Name { get; set; }
        public string? Image { get; set; }


    }
}
