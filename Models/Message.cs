using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public int TravelPackageId { get; set; }
        public TravelPackage? TravelPackage { get; set; }

        //public Message()
        //{
        //    TravelPackage = new();
        //}
    }
}
