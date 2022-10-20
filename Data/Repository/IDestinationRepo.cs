using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data.Repository
{
    public interface IDestinationRepo
    {
        public List<Destination> GetAll();
        public TravelPackage Get(int id);
        public void Delete(int id);
        public void Update(Destination item );
        public void Create(Destination item);
    }
}
