using MB.MCPP.HappyBusiness.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.MCPP.HappyBusiness.Dtos.Buyers
{
    public class BuyerDetailsDto
    {
        public BuyerDetailsDto()
        {
            //Deals = new List<Deal>();
        }

        public int Id { get; set; }
        public string CodeName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public int Discount { get; set; }

        //public List<Deal> Deals { get; set; }
    }
}
