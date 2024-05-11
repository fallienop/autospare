using AutoSpare.Application.Repositories.PlateRepo;
using AutoSpare.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Plates.GetPlateWithFilter
{
    public class GetPlateWithFilterQueryHandler : IRequestHandler<GetPlateWithFilterQueryRequest, GetPlateWithFilterQueryResponse>
    {
        private readonly IPlateReadRepository _repository;

        public GetPlateWithFilterQueryHandler(IPlateReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetPlateWithFilterQueryResponse> Handle(GetPlateWithFilterQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Plate, bool>> expression = p => EF.Functions.Like(p.Number,request.Pattern);
            //p.Number.Contains(request.FilterPattern);

            // Call the repository method with the expression
            var plate = _repository.GetWhere(x=> EF.Functions.Like(x.Number, request.Pattern));
            //var plate = _repository.GetWithQueryAsync(x=>x));
         
           
            var resp= new GetPlateWithFilterQueryResponse()
            {
                Plate = plate
            };

            return Task.FromResult(resp);

        }
    }
}
