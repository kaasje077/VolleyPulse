using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO_s
{
    public class Coach : Member
    { 
        public int id { get; set; }
        public string? contactNumber { get; set; }
        public int MemberID { get; set; }
    }
}

