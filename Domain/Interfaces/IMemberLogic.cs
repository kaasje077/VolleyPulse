using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTO_s;

namespace Domain.Interfaces
{
    public interface IMemberLogic
    {
        public Member AuthenticateMember(string email, string password);
        public Player GetPlayerByMemberId(int memberId);
    }
}
