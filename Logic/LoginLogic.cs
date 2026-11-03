using Domain.DTO_s;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class LoginLogic : ILoginLogic
    {
        private readonly ILoginRepository _repo;

        public LoginLogic(ILoginRepository repo)
        {
            _repo = repo;
        }

        public Member AuthenticateMember(string email, string password)
        {
            return _repo.AuthenticateMember(email, password);
        }
    }
}
