using System;
using System.Collections.Generic;
using System.Text;
using Logic.Interfaces;
using Logic.DTO_s;

namespace Logic
{
    public class AttendanceLogic : IAttendanceLogic
    {
        private readonly IAttendanceRepository _repo;

        public AttendanceLogic(IAttendanceRepository repo)
        {
            _repo = repo;
        }

        public void MarkAttendance(Attendance attendance)
        {
            _repo.MarkAttendance(attendance);
        }
    }
}
