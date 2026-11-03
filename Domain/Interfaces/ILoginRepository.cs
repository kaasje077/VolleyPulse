using Domain.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ILoginRepository
    {
        public Member AuthenticateMember(string email, string password);
    }
}
