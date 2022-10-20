using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Destination
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<TravelPackage> Packages { get; set; }
    }
}