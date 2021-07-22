using CodingEvents.Data;
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

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIDs)
        {
            foreach(int eventID in eventIDs)
            {
                EventData.Remove(eventID);
            }
            return Redirect("/Events");
        }

        [Route("/Events/Edit/{eventID?}")]
        public IActionResult Edit(int eventID)
        {
            Event eventToEdit = EventData.GetByID(eventID);
            ViewBag.eventToEdit = eventToEdit;
            ViewBag.title = $"Edit Event {eventToEdit.Name}(id = {eventToEdit.ID})";
            return View();
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventID, string name, string description)
        {

        }
    }
}
