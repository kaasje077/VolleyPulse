using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO_s
{
    public class Competition : Event
    {
        public int EventID { get; set; }
        public string opponent { get; set; } = string.Empty;
        public TimeSpan arrivalTime { get; set; }
    }
}
