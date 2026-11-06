using Domain.DTO_s;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Enums;

namespace UI.Pages.Teams.Member.Player
{
    public class MarkAttendanceModel : PageModel
    {
        private readonly IAttendanceLogic _attendanceLogic;
        private readonly IEventLogic _eventLogic;
        private readonly IMemberLogic _loginLogic;

        public MarkAttendanceModel(IAttendanceLogic attendanceLogic, IEventLogic eventLogic, IMemberLogic loginLogic)
        {
            _attendanceLogic = attendanceLogic;
            _eventLogic = eventLogic;
            _loginLogic = loginLogic;
        }

        public Domain.DTO_s.Practice Practice { get; private set; }
        public Domain.DTO_s.Event Event { get; private set; }
        public Domain.DTO_s.Attendance Attendance { get; private set; }


        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public IActionResult OnPostPresent()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("MemberId"));

            Domain.DTO_s.Player player = _loginLogic.GetPlayerByMemberId(memberId);

            Attendance attendance = new Attendance
            {
                timeStamp = DateTime.Now,
                Status = Status.present,
                PlayerID = player.id,
                EventID = id
            };
            _attendanceLogic.MarkAttendance(attendance);

            return RedirectToPage("/Schedule/Details", new { id });
        }

        public IActionResult OnPostAbsent()
        {
            int memberId = int.Parse(HttpContext.Session.GetString("MemberId"));

            Domain.DTO_s.Player player = _loginLogic.GetPlayerByMemberId(memberId);

            Attendance attendance = new Attendance
            {
                timeStamp = DateTime.Now,
                Status = Status.absent,
                PlayerID = player.id,
                EventID = id
            };

            _attendanceLogic.MarkAttendance(attendance);

            return RedirectToPage("/Schedule/Details", new { id });
        }

        public IActionResult OnGet(int id)
        {
            Practice = _eventLogic.GetPracticeById(id);

            int memberId = int.Parse(HttpContext.Session.GetString("MemberId"));

            var player = _loginLogic.GetPlayerByMemberId(memberId);

            Attendance = _attendanceLogic.GetAttendanceByPlayerAndEvent(
                player.id,
                id);

            return Page();
        }
    }
}
