using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        
        public IActionResult Update(int id) {
            TravelPackageViewModel tpvm = new();
            tpvm.TravelPackage = _travelPackagesRepo.Get(id);
            tpvm.Destinations = _destinationRepo.GetAll();
            tpvm.Categories= _categoryRepo.GetAll();
            return View(tpvm);
        }
        [HttpPost]
        public IActionResult Update(int id , TravelPackageViewModel item) {
            if (!ModelState.IsValid) {
                item.TravelPackage = _travelPackagesRepo.Get(id);
                item.Categories = _categoryRepo.GetAll();
                item.Destinations = _destinationRepo.GetAll();
            }
            var tpOld = _ctx.TravelPackages.Include("Category").Include("Destinations").Where(x => x.Id == id).FirstOrDefault();
            List<Destination> destinazioni = _ctx.Destinations.Where(x => item.SelectedDestinations.Contains(x.Id)).ToList();
            tpOld.Name = item.TravelPackage.Name;
            tpOld.Description = item.TravelPackage.Description;
            tpOld.CategoryId = item.TravelPackage.CategoryId;
            tpOld.Price = item.TravelPackage.Price;
            tpOld.Dutation = item.TravelPackage.Dutation;
            tpOld.Destinations = destinazioni;
            _ctx.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Delete(int id) {
            _travelPackagesRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
