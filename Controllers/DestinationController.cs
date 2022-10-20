using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Data.Repository;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class DestinationController : Controller
    {
        DbDestinationRepo _repo;
        public DestinationController(DbDestinationRepo repo) {
            _repo = repo ;
        }
        [Authorize]
        public IActionResult Index()
        {
            List<Destination> destinations = _repo.GetAll();
        return View(destinations);
        }
        //[HttpGet("{id}")] 
        //public IActionResult Detail(int id) {
        //    Destination dest = _repo.Get(id);
        //    return View(dest);
        //}
        public IActionResult Delete(int id) {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
