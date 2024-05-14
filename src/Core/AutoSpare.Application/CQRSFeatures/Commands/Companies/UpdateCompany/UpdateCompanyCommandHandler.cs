using AutoSpare.Application.Repositories.CompanyRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Companies.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommandRequest, UpdateCompanyCommandResponse>
    {
        private readonly ICompanyWriteRepository _repository;

        public UpdateCompanyCommandHandler(ICompanyWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            //var company = await _repository.Table.FindAsync(request.Company.Id);
            //if (company == null)
            //{
            //    return new() { Success = false };

            //}
            //company.Name = request.Company.Name;
            _repository.Update(request.Company);
            var resp = await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0
            };
        }
    }
}
