using Microsoft.AspNetCore.Mvc.Rendering;

namespace webapp_travel_agency.Models
{
    public class TravelPackageViewModel
    {
        public TravelPackage? TravelPackage { get; set; }
        public List<Destination>? Destinations { get; set; }
        public List<Category>? Categories { get; set; }
        public List<int> SelectedDestinations { get; set; }

        public TravelPackageViewModel() {
            TravelPackage = new();
            Destinations = new();
            Categories = new();
            SelectedDestinations = new();
        }
    }

    
}
