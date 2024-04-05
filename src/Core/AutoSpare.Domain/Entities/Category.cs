using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; } 
        public List<Category>? Subcategories { get; set; }
        public string ImageName { get; set; }
    }
}
