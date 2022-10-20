using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data.Repository;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        DbTravelPackageRepo repo;
        public HomeController(DbTravelPackageRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll() {

            var pkts = repo.GetAll();
            if (pkts == null) {
                return NoContent();
            }
            return Ok(pkts);
        }
    }
}
