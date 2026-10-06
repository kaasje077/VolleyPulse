using Logic.DTO_s;
using Logic.Interfaces;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.NetworkInformation;

namespace UI.Pages.Schedule
{
    public class DetailsModel : PageModel
    {
        private readonly IEventLogic _logic;

        public DetailsModel(IEventLogic logic)
        {
            _logic = logic;
        }

        public Logic.DTO_s.Event Event { get; private set; }
        public Logic.DTO_s.Attendance Attendance { get; private set; }

        public IActionResult OnGet(int id)
        {
            Event = _logic.GetEventById(id);

            if (Event == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
