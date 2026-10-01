using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO_s
{
    public class Admin : Member
    { 
        public int id = 2;
        public string? contactNumber { get; set; }
        public int MemberID { get; set; }
    }
}

