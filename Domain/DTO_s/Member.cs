using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.DTO_s
{
    public class Member
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        private DateOnly doB { get; set; }
        public string passwordHash { get; set; }
        public Role Role { get; set; }
    }
}
