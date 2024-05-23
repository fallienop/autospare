using AutoSpare.Domain.Entities.Product;

//namespace AutoSpare.Application.DTOs
//{
//    public class PartResponseDTO
//    {
//        public string Name { get; set; } = null!;

//        public string ModelName { get; set; } = null!;


//        public ushort StartYear { get; set; }


//        public ushort EndYear { get; set; }


//        public decimal Price { get; set; }


//        public ushort Stock { get; set; }




//        public byte[]? Image1 { get; set; }
//        public byte[]? Image2 { get; set; }
//        public byte[]? Image3 { get; set; }



//        public string CategoryName { get; set; }


//        public string? BrandName { get; set; }


//        public string? CompanyName { get; set; }

//        public string Description { get; set; }
//        public string Code { get; set; }
//    }
//}


namespace AutoSpare.Application.DTOs
{
    public class PartResponseDTO
    {
        public string Name { get; set; } = null!;
        public string ModelName { get; set; } = null!;
        public ushort StartYear { get; set; }
        public ushort EndYear { get; set; }
        public decimal Price { get; set; }
        public ushort Stock { get; set; }
        public byte[]? Image1 { get; set; }
        public byte[]? Image2 { get; set; }
        public byte[]? Image3 { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? BrandName { get; set; }
        public string? CompanyName { get; set; }
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
