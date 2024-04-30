using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Companies.DeleteCompany
{
    public class DeleteCompanyCommandRequest : IRequest<DeleteCompanyCommandResponse>
    {
        public string Id { get; set; }

    }
}
