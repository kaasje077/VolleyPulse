using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO_s
{
    public class Practice : Event
    {
        public int EventID { get; set; }
        public TimeSpan endTime { get; set; }
    }
}
