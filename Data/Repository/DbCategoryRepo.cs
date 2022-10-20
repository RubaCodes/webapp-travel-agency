using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data.Repository
{
    public class DbCategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _context;
        public DbCategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Category item)
        {
            Category category = new Category();
            category = item;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Category item)
        {
            _context.Categories.Update(item);
            _context.SaveChanges();
        }
    }
}
