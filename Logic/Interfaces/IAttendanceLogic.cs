using System;
using System.Collections.Generic;
using System.Text;
using Logic.DTO_s;
using Logic.Interfaces;

namespace Logic.Interfaces
{
    public interface IAttendanceLogic
    {
        public void MarkAttendance(Attendance attendance);
    }
}
