using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Interfaces;

namespace UI.Pages.Teams.Member.Coach
{
    public class CreatePracticeModel : PageModel
    {
        private readonly IEventLogic _logic;

        public CreatePracticeModel(IEventLogic logic)
        {
            _logic = logic;
        }

        [BindProperty]
        public DateTime date { get; set; }

        [BindProperty]
        public TimeSpan startTime { get; set; }

        [BindProperty]
        public TimeSpan endTime { get; set; }

        [BindProperty]
        public string location { get; set; } = string.Empty;

        [BindProperty]
        public string? notes { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var NewEvent = new Logic.DTO_s.Event
            {
                date = date,
                startTime = startTime,
                location = location,
                notes = notes,
                AdminID = 2
            };

            _logic.CreatePractice(NewEvent, endTime);

            return RedirectToPage("/Schedule/Index");
        }
    }
}
