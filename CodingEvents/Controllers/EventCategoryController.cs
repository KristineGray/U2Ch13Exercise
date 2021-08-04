using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbcontext)
        {
            context = dbcontext;
        }

        public IActionResult Index()
        {
            List<EventCategory> eventCategories = context.EventCategories.ToList();
            return View(eventCategories);
        }
    }
}
