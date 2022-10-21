using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Data;
using webapp_travel_agency.Data.Repository;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        DbTravelPackageRepo _repo;
        ApplicationDbContext _ctx;
        public HomeController(DbTravelPackageRepo repo, ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll(string? search) {
            if (search == null)
            {
                var pkts = _repo.GetAll();
                if (pkts == null)
                {
                    return NoContent();
                }
                return Ok(pkts);
            }
            else {
               var pkts = _ctx.TravelPackages.Include("Category").Include("Destinations").Where(x => x.Name.Contains(search) || x.Description.Contains(search)).ToList();
                return Ok(pkts);
            }
        }
        public IActionResult Get(int id) {
            var tp =_repo.Get(id);
            if (tp == null)
            {
                return NoContent();
            }
            else {
                return Ok(tp);
            }
        }
    }
}
