using AutoSpare.Application.Repositories.CompanyRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Companies.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommandRequest, DeleteCompanyCommandResponse>
    {
        private readonly ICompanyWriteRepository _repository;

        public DeleteCompanyCommandHandler(ICompanyWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCompanyCommandResponse> Handle(DeleteCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveByIdAsync(request.Id);
            var resp = await _repository.SaveAsync();
            return new()
            {
                Success = resp > 0
            };
        }
    }
}
