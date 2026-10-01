using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO_s
{
    public class Player : Member
    {
        public int id { get; set; }
        public Enum? Position { get; set; }
        public int number { get; set; }
        public int MemberID { get; set; }


    }
}
