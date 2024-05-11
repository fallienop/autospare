using AutoSpare.Domain.Entities.Common;

namespace AutoSpare.Domain.Entities
{
    public class Plate : BaseEntity
    {

        public string  Number    { get; set; }
        public decimal Price    { get; set; }
        public string  Location { get; set; }
        public string  Name     { get; set; }
        public string  Phone    { get; set; }
        public string?  Views    { get; set; }

    }
}
