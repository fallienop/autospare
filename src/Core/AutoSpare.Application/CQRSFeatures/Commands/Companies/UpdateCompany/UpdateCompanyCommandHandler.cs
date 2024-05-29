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
            var company = await _repository.Table.FindAsync(request.Id);
            if(request.Name!=null)
            {
            company.Name = request.Name;
            }
             
            if(request.Phone!=null)
            {
            company.Phone = request.Phone;
            }

            if (request.Address != null)
            {
                company.Address = request.Address;
            }
            if (request.Website != null)
            {
                company.Website = request.Website;
            }
            if (request.WorkStart != null)
            {
                company.WorkStart = request.WorkStart;
            }
            if (request.WorkEnd != null)
            {
                company.WorkEnd = request.WorkEnd;
            }

            var image = request.Image;
            if (image == "deleted")
            {
                company.Image = null;
            }
            else if (image == "same")
            {

            }
            else
            {

                byte[] imageByte = [];
                if (image != null)
                {
                    imageByte = Convert.FromBase64String(image.Substring(image.LastIndexOf(',') + 1));
                }
                company.Image = imageByte;

            }
            _repository.Update(company);
            var resp = await _repository.SaveAsync();

            return new()
            {
                Success = resp > 0
            };
        }
    }
}
