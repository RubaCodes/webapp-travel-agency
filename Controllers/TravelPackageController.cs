using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Data.Repository;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class TravelPackageController : Controller
    {
        DbTravelPackageRepo _travelPackagesRepo;
        DbCategoryRepo _categoryRepo;
        DbDestinationRepo _destinationRepo;
        ApplicationDbContext _ctx;
        public TravelPackageController(DbTravelPackageRepo travel, DbCategoryRepo cat, DbDestinationRepo dest, ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _travelPackagesRepo = travel;
            _categoryRepo = cat;
            _destinationRepo = dest;
        }
        public IActionResult Index()
        {
            List<TravelPackage> pkts = _travelPackagesRepo.GetAll();
            return View(pkts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var tpvm = new TravelPackageViewModel();
            tpvm.Categories = _categoryRepo.GetAll();
            tpvm.Destinations = _destinationRepo.GetAll();
            return View(tpvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelPackageViewModel tpvm)
        {
            if (!ModelState.IsValid)
            {
                tpvm.Destinations = _destinationRepo.GetAll();
                tpvm.Categories = _categoryRepo.GetAll();
                return View(tpvm);
            }
            List<Destination> destinazioni = _ctx.Destinations.Where(x => tpvm.SelectedDestinations.Contains(x.Id)).ToList();
            _travelPackagesRepo.Create(tpvm.TravelPackage, destinazioni);

            return RedirectToAction("Index");
        }
    }
}
