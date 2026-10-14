using System;
using System.Collections.Generic;
using System.Text;
using Logic.DTO_s;
using Logic.Interfaces;

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
