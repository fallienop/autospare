using AutoSpare.Application.Repositories.OrderRepo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Orders.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommandRequest, ChangeOrderStatusCommandResponse>
    {
        private readonly IOrderReadRepository _readRepository;
        private readonly IOrderWriteRepository _writeRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public ChangeOrderStatusCommandHandler(IOrderReadRepository readRepository, IOrderWriteRepository writeRepository, IHttpContextAccessor contextAccessor)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<ChangeOrderStatusCommandResponse> Handle(ChangeOrderStatusCommandRequest request, CancellationToken cancellationToken)
        {
            var adminCompanyId=_contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "companyId");
            var order =await _readRepository.GetWhere(o => o.Id.ToString() == request.OrderId).Include(x=>x.OrderPart).ThenInclude(x=>x.Part).FirstAsync();
          
           var orderpart= order.OrderPart.Where(x=>x.PartId==request.PartId).FirstOrDefault();
            if (orderpart.Part.CompanyId.ToString() != adminCompanyId.Value)
            {
                throw new Exception("Unauthorized");
            }
            orderpart.Status = request.Status;
           _writeRepository.Update(order);
          var resp=  await _writeRepository.SaveAsync();
            return new() { Success = resp > 0 };
        }
    }
}
