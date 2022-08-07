namespace MB.MCPP.HappyBusiness.Dtos.Drugs
{
    public class DrugDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public double Price { get; set; }
        public string? ImageName { get; set; }
        public int Rating { get; set; }
        public int ClassificationId { get; set; }
    }
}
