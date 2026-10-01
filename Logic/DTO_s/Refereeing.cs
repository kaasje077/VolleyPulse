using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO_s
{
    public class Refereeing : Event
    {
        public int EventID { get; set; }
        public string teamToReferee { get; set; } = string.Empty;
    }
}
