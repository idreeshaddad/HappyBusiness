using MB.MCPP.HappyBusiness.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.MCPP.HappyBusiness.Dtos.Deals
{
    public class DealDetailsDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime DealTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public Guid TransactionCode { get; set; }

        public int BuyerId { get; set; }

        public int PharmacistId { get; set; }
    }
}
