using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data.Repository
{
    public interface ICategoryRepo
    {
        public List<Category> GetAll();
        public Category Get(int id);
        public void Delete(int id);
        public void Update(Category item );
        public void Create(Destination item);
    }
}
