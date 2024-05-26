using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Orders.GetOrdersOfCompany
{
    public class OrderOfCompanyReturnDTO
    {
        public Guid OrderId { get; set; }
        //public string AppUserId { get; set; }
        public string NameSurname { get; set; }
        public Guid PartId { get; set; }
        public string PartName { get;set; }
        public string PartCode {  get; set; }
        //public Guid? CompanyId { get; set; }
        public int Count { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
