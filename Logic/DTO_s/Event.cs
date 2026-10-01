using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO_s
{
    public class Event
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public TimeSpan startTime { get; set; }
        public string location { get; set; } = string.Empty;
        public string? notes { get; set; }
        public int AdminID { get; set; }
    }
}
