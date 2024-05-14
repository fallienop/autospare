using AutoSpare.Application.Repositories.CompanyRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Companies.AddCompany
{
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommandRequest, AddCompanyCommandResponse>
    {
        private readonly ICompanyWriteRepository _repository;

        public AddCompanyCommandHandler(ICompanyWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddCompanyCommandResponse> Handle(AddCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new() { Name = request.Name,Image=request.Image });
            var resp = await _repository.SaveAsync();
            return new()
            {
                Success = resp > 0
            };
        }
    }
}
