using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Data;
using webapp_travel_agency.Data.Repository;
using webapp_travel_agency.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Text;

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
        public IActionResult Detail(int id ) {
            var tp = _travelPackagesRepo.Get(id);
            return View(tp);
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

        //tentativo di export della tabella pacchetti
        public IActionResult Export() {
            var tablePackage = _travelPackagesRepo.GetAll();
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true)))
                {
                    using (var cw = new CsvWriter(sw, cc))
                    {
                        cw.WriteRecords(tablePackage);
                    }// The stream gets flushed here.
                    return File(ms.ToArray(), "text/csv", $"export_{DateTime.UtcNow.Ticks}.csv");
                }
            }
        }
    }
}
