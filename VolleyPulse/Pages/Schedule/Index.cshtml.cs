using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.DTO_s;
using System.Globalization;
using Domain.Enums;

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
        public List<Competition> Competitions { get; private set; } = new();
        public Member Member { get; private set; }

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