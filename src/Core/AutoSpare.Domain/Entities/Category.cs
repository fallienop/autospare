using AutoSpare.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSpare.Domain.Entities
{
    public class Category : BaseEntity
    {

        public string Name { get; set; } = null!;
        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Category>? Subcategories { get; set; }
        public Guid CategoryId { get; set; }


        public byte[]? Image { get; set; }

    }
}
