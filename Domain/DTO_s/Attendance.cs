using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.DTO_s
{
    public class Attendance
    {
        public int id { get; set; }
        public DateTime timeStamp { get; set; }
        public Status Status { get; set; }
        public int PlayerID { get; set; }
        public int EventID { get; set; }
    }
}
