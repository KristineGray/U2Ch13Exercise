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
            // a. Use an EventData method to find the event object with the given eventId
            Event eventToEdit = EventData.GetByID(eventID);
            // b. Put the event object in ViewBag
            ViewBag.eventToEdit = eventToEdit;
            // c. Return the appropriate view

        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventID, string name, string description)
        {

        }
    }
}
