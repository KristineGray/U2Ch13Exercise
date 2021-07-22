using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //private static Dictionary<string, string> Events = new Dictionary<string, string>();
        private static List<Event> Events = new List<Event>();


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

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string inputName, string inputDescription)
        {
            Events.Add(new Event(inputName, inputDescription));
            return Redirect("/Events");
        }
    }
}
