using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data.Repository
{
    public interface ITravelPackageRepo
    {
        public List<TravelPackage> GetAll();
        public TravelPackage Get(int id);
        public List<TravelPackage> Get(string name);
        public void Delete(int id);
        public void Update(TravelPackage item, List<Destination> destinations);
        public void Create(TravelPackage item, List<Destination> destinnations);
    }
}
