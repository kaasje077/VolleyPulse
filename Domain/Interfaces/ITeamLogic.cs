using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTO_s;

namespace Domain.Interfaces
{
    public interface ITeamLogic
    {
        List<Team> GetAllTeams();
    }
}
