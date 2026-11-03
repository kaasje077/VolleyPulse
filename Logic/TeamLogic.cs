using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTO_s;
using Domain.Interfaces;

namespace Logic
{
    public class TeamLogic : ITeamLogic
    {
        private readonly ITeamRepository _repo;

        public TeamLogic(ITeamRepository repo)
        {
            _repo = repo;
        }
        public List<Team> GetAllTeams()
        {
            return _repo.GetAllTeams();
        }
    }
}
