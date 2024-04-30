using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Categories.DeleteCategoryById
{
    public class DeleteCategoryByIdCommandRequest : IRequest<DeleteCategoryByIdCommandResponse>
    {
        public string Id { get; set; }
    }
}
