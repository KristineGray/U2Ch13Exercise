using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext context;
        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Event> events = context.Events.ToList();

            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Type = addEventViewModel.Type,
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Location = addEventViewModel.Location,
                    NumAttending = addEventViewModel.NumAttending,
                    IsRegistrationRequired = addEventViewModel.IsRegistrationRequired
                };
                context.Events.Add(newEvent);
                context.SaveChanges();
                return Redirect("/Events");
            }
            
            return View(addEventViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.Events.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIDs)
        {
            foreach(int eventID in eventIDs)
            {
                Event theEvent = context.Events.Find(eventID);
                context.Events.Remove(theEvent);
            }
            context.SaveChanges();
            return Redirect("/Events");
        }

        //[Route("/Events/Edit/{eventID?}")]
        public IActionResult Edit(int id)
        {
            Event eventToEdit = EventData.GetByID(id);
            ViewBag.eventToEdit = eventToEdit;
            ViewBag.title = $"Edit Event {eventToEdit.Name}(id = {eventToEdit.ID})";
            return View();
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int id, string name, string description)
        {
            Event eventToEdit = EventData.GetByID(id);
            eventToEdit.Name = name;
            eventToEdit.Description = description;
            return Redirect("/Events");
        }
    }
}
