using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage ="Location for event is required")]
        public string Location { get; set; }

        [Required(ErrorMessage ="Number of attendees for event is required")]
        [Range(0, 100000, ErrorMessage ="Number of attendees must be a number between 0 and 100,000")]
        public int NumAttending { get; set; }

        public bool IsTrue { get { return true; } }
        
        [Required(ErrorMessage ="Must include whether or not registration is required")]
        [Compare(nameof(IsTrue), ErrorMessage = "Event must require attendee registration")]
        public bool IsRegistrationRequired { get; set; }
        public EventType Type { get; set; }
        public List<SelectListItem> EventTypes { get; set; }
    }
}
