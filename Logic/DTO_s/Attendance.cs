using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO_s
{
    public class Attendance
    {
        public int id { get; set; }
        public DateTime timeStamp { get; set; }
        public string? status { get; set; }
        public int PlayerID { get; set; }
        public int EventID { get; set; }
    }
}
