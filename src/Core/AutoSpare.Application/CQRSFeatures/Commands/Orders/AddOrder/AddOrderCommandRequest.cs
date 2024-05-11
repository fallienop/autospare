using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Orders.AddOrder
{
    public class AddOrderCommandRequest : IRequest<AddOrderCommandResponse>
    {
        public string ProductId { get; set; }

    }
}
