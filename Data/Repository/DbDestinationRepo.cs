using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data.Repository
{
    public class DbDestinationRepo : IDestinationRepo
    {
        private readonly ApplicationDbContext _context;
        public DbDestinationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Destination item)
        {
            Destination destination = new();
             destination = item;
            _context.Add(destination);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
             Destination destination = _context.Destinations.FirstOrDefault(c => c.Id == id);
            _context.Destinations.Remove(destination);
            _context.SaveChanges();
        }

        public Destination Get(int id)
        {
            return _context.Destinations.FirstOrDefault(x => x.Id == id);
        }

        public List<Destination> GetAll()
        {
            return _context.Destinations.ToList();
        }

        public void Update(Destination item)
        {
            _context.Destinations.Update(item);
            _context.SaveChanges();
        }
    }
}
