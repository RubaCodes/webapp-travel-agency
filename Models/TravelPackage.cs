using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class TravelPackage
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImgSource { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Dutation { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Destination>? Destinations { get; set; }
        public List<Message> Messages { get; set; }
    }
}
