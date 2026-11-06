using Domain.DTO_s;
using Domain.Interfaces;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.NetworkInformation;

namespace UI.Pages.Schedule
{
    public class DetailsModel : PageModel
    {
        private readonly IEventLogic _eventLogic;
        private readonly IMemberLogic _memberLogic;
        private readonly IAttendanceLogic _attendanceLogic;

        public DetailsModel(IEventLogic eventLogic, IMemberLogic memberLogic, IAttendanceLogic attendanceLogic)
        {
            _eventLogic = eventLogic;
            _memberLogic = memberLogic;
            _attendanceLogic = attendanceLogic;
        }

        public Domain.DTO_s.Practice Practice { get; private set; }
        public Domain.DTO_s.Event Event { get; private set; }
        public Domain.DTO_s.Attendance Attendance { get; private set; }

        public IActionResult OnGet(int id)
        {
            Practice = _eventLogic.GetPracticeById(id);

            string role = HttpContext.Session.GetString("MemberRole");

            if (role != "Coach")
            {
                int memberId = int.Parse(HttpContext.Session.GetString("MemberId"));

                var player = _memberLogic.GetPlayerByMemberId(memberId);

                if (player != null)
                {
                    Attendance = _attendanceLogic.GetAttendanceByPlayerAndEvent(
                        player.id,
                        id);
                }
            }

            return Page();
        }
    }
}
