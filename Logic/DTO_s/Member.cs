using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTO_s
{
    public class Member
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        private DateOnly doB { get; set; }
        private string passwordHash { get; set; }
    }
}
