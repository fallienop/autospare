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
            var image = request.Image;
            byte[] imageByte = [];
            if (image != null)
            {
                imageByte = Convert.FromBase64String(image.Substring(image.LastIndexOf(',') + 1));
            }


            await _repository.AddAsync(new() { Name = request.Name,Image=imageByte });
            var resp = await _repository.SaveAsync();
            return new()
            {
                Success = resp > 0
            };
        }
    }
}
