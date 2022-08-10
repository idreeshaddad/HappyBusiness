using MB.MCPP.HappyBusiness.Dtos.Drugs;
using MB.MCPP.HappyBusiness.Utils.Enums;

namespace MB.MCPP.HappyBusiness.Dtos.Deals
{
    public class DealDetailsDto
    {
        public DealDetailsDto()
        {
            Drugs = new List<DrugListDto>();
            //DrugStreetNames = new List<string>();
        }

        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime DealTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public Guid TransactionCode { get; set; }

        public int BuyerId { get; set; }

        public int PharmacistId { get; set; }

        public List<DrugListDto> Drugs { get; set; }

        //public List<string> DrugStreetNames { get; set; }
    }
}
