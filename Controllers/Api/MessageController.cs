using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        ApplicationDbContext db;
        public MessageController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public IActionResult Send(int idPackage, Message message) {
            var pkg = db.TravelPackages.Find(idPackage);
            if (pkg == null) {
                return NotFound("Il travel package selezionato non esiste");
            }
            Message msg = new();
            msg = message;
            message.TravelPackageId = idPackage;
            db.Messages.Add(msg);
            db.SaveChanges();
            return Ok("Messagge inviato correttamente");

        }
    }
}
