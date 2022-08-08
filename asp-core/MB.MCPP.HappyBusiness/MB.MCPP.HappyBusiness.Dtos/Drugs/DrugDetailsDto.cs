namespace MB.MCPP.HappyBusiness.Dtos.Drugs
{
    public class DrugDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public double Price { get; set; }
        public string? ImageName { get; set; }
        public int Rating { get; set; }
        public string ClassificationName { get; set; }
    }
}
