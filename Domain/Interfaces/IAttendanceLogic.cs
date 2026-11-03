using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTO_s;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IAttendanceLogic
    {
        public void MarkAttendance(Attendance attendance);
    }
}
