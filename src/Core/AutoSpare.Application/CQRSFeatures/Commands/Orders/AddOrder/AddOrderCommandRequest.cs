using AutoSpare.Application.DTOs;
using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Commands.Orders.AddOrder
{
    public class AddOrderCommandRequest : IRequest<AddOrderCommandResponse>
    {
        public List<PartNCount> PartsandCounts { get; set; }
        public string Address { get; set; }

    }
}
