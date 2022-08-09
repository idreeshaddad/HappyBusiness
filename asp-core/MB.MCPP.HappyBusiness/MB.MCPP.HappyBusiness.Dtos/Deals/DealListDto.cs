using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.MCPP.HappyBusiness.Dtos.Deals
{
    public class DealListDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DealTime { get; set; }

        public string BuyerCodeName { get; set; }
        public string PharmacistFirstName { get; set; }
    }
}
