using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.DTO_s;
using System.Globalization;

namespace UI.Pages.Schedule
{
    public class IndexModel : PageModel
    {
        private readonly IEventLogic _eventLogic;

        public IndexModel(IEventLogic eventLogic)
        {
            _eventLogic = eventLogic;
        }

        public List<Practice> Practices { get; private set; } = new();

        public int CurrentWeek { get; set; }
        public int CurrentYear { get; set; }

        public IActionResult OnGet(int? week)
        {
            CurrentWeek = week ?? ISOWeek.GetWeekOfYear(DateTime.Today);
            CurrentYear = ISOWeek.GetYear(DateTime.Today);

            Practices = _eventLogic.GetAllPractices()
            .Where(p =>
            ISOWeek.GetWeekOfYear(p.date) == CurrentWeek &&
            ISOWeek.GetYear(p.date) == CurrentYear)
            .OrderBy(p => p.date)
            .ToList();

            return Page();
        }
    }
}