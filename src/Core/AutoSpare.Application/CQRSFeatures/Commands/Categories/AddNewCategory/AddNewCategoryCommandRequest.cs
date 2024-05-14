using AutoSpare.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Categories.AddNewCategory
{
    public class AddNewCategoryCommandRequest : IRequest<AddNewCategoryCommandResponse>
    {
        public string Name { get; set; } = null!;
        public Guid? ParentCategoryId { get; set; }

        public string? Image { get; set; }
    }
}
