using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTO_s;

namespace Domain.Interfaces
{
    public interface IAttendanceRepository
    {
        public void MarkAttendance(Attendance attendance);
        public Attendance GetAttendanceByPlayerAndEvent(int playerId, int eventId);
    }
}
