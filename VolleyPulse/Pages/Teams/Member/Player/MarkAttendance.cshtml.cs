using Logic.DTO_s;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Teams.Member.Player
{
    public class MarkAttendanceModel : PageModel
    {
        private readonly IAttendanceLogic _attendanceLogic;
        private readonly IEventLogic _eventLogic;

        public MarkAttendanceModel(IAttendanceLogic attendanceLogic, IEventLogic eventLogic)
        {
            _attendanceLogic = attendanceLogic;
            _eventLogic = eventLogic;
        }

        public Logic.DTO_s.Practice Practice { get; private set; }
        public Logic.DTO_s.Event Event { get; private set; }
        public Logic.DTO_s.Attendance Attendance { get; private set; }


        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public IActionResult OnPostPresent()
        {
            Attendance attendance = new Attendance
            {
                timeStamp = DateTime.Now,
                status = "Present",
                PlayerID = 1, // temporary
                EventID = id
            };

            _attendanceLogic.MarkAttendance(attendance);

            return RedirectToPage("/Schedule/Index");
        }

        public IActionResult OnPostAbsent()
        {
            Attendance attendance = new Attendance
            {
                timeStamp = DateTime.Now,
                status = "Absent",
                PlayerID = 1, // temporary
                EventID = id
            };

            _attendanceLogic.MarkAttendance(attendance);

            return RedirectToPage("/Schedule/Index");
        }

        public IActionResult OnGet(int id)
        {
            Practice = _eventLogic.GetPracticeById(id);

            if (Practice == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
