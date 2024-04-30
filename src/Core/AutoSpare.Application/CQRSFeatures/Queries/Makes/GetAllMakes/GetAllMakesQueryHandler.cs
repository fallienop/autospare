using AutoSpare.Application.Repositories.ProductRepos.MakeRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Makes.GetAllMakes
{
    public class GetAllMakesQueryHandler : IRequestHandler<GetAllMakesQueryRequest, GetAllMakesQueryResponse>
    {
       private readonly IMakeReadRepository _makeReadRepository;

        public GetAllMakesQueryHandler(IMakeReadRepository makeReadRepository)
        {
            _makeReadRepository = makeReadRepository;
        }

        public Task<GetAllMakesQueryResponse> Handle(GetAllMakesQueryRequest request, CancellationToken cancellationToken)
        {

            //var makes =  _makeReadRepository.GetAll(false).Skip(request.Page*request.Size).Take(request.Size).ToList();
            var makes =  _makeReadRepository.GetAll(false);
            var response = new GetAllMakesQueryResponse()
            {
                Makes = makes
            };

            return Task.FromResult(response);

        }

       
    }
}
