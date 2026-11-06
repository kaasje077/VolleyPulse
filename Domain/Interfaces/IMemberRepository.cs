using Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IMemberRepository
    {
        public Member AuthenticateMember(string email, string password);
        public Player GetPlayerByMemberId(int memberId);
    }
}
