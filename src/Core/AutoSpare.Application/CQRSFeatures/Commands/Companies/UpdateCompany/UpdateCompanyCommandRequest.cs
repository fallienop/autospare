using AutoSpare.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Companies.UpdateCompany
{
    public class UpdateCompanyCommandRequest : IRequest<UpdateCompanyCommandResponse>
    {
        public Company Company { get; set; }
    }
}
