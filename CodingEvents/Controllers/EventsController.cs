using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        // 1. Let’s convert our Events list to a Dictionary.
            // Dictionary contains name of event & description
        private static Dictionary<string, string> Events = new Dictionary<string, string>();


        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = Events;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // 3. Add the description parameter to the NewEvent action method and within the method, add the new event key/value pair to the Events dictionary.
        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string name)
        {
            Events.Add(name);
            return Redirect("/Events");
        }
    }
}
