using Domain.DTO_s;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class MemberLogic : IMemberLogic
    {
        private readonly IMemberRepository _repo;

        public MemberLogic(IMemberRepository repo)
        {
            _repo = repo;
        }

        public Member AuthenticateMember(string email, string password)
        {
            return _repo.AuthenticateMember(email, password);
        }

        public Player GetPlayerByMemberId(int memberId)
        {
            return _repo.GetPlayerByMemberId(memberId);
        }
    }
}
