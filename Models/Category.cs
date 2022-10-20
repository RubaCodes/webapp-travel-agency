namespace webapp_travel_agency.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TravelPackage> TravelPackages { get; set; }
    }
}