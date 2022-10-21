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
        public IActionResult Send( Message message) {
            var pkg = db.TravelPackages.Where(x => x.Id == message.TravelPackageId).FirstOrDefault(); ;
            if (pkg == null)
            {
                return NotFound("Il travel package selezionato non esiste");
            }
            Message msg = new();
            msg = message;
            
            db.Messages.Add(msg);
            db.SaveChanges();
            return Ok("Messagge inviato correttamente");

        }
    }
}
