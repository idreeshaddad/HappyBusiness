using MB.MCPP.HappyBusiness.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.MCPP.HappyBusiness.Dtos.Deals
{
    public class DealDto
    {
        public int Id { get; set; }
        public PaymentType PaymentType { get; set; }

        public int BuyerId { get; set; }

        public int PharmacistId { get; set; }

        //public List<Drug> Drugs { get; set; }
    }
}
