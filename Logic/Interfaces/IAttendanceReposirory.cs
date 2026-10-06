using System;
using System.Collections.Generic;
using System.Text;
using Logic.DTO_s;

namespace Logic.Interfaces
{
    public interface IAttendanceRepository
    {
        public void MarkAttendance(Attendance attendance);
    }
}
