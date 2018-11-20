using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using TournamentWebApp.DataAccess;
using TournamentWebApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TournamentWebApp.Controllers
{

    [Route("api/[controller]")]
    public class TournamentController : Controller
    {
        [FromServices]
        public IGenericRepository<Tournament> Repository { get; set; }

        [FromServices]
        public ILogger<TournamentController> Logger { get; set; }

        [HttpGet]
        public IEnumerable<Tournament> GetAll()
        {
            return Repository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTournament")]
        public IActionResult FindById(int id)
        {
            var item = Repository.FindBy(i => i.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    var tournaments = DataContext.Tournaments;
        //    return View(tournaments);
        //}
    }
}
