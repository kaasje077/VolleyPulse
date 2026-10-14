using Logic.DTO_s;
using Logic.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repo
{
    public class TeamRepository : ITeamRepository
    {
        private readonly string _connectionString;

        public TeamRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Team> GetAllTeams()
        {
            var teams = new List<Team>();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(
                @"SELECT * FROM Team",
                conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                teams.Add(new Team
                {
                    id = reader.GetInt32(reader.GetOrdinal("id")),
                    name = reader.GetString(reader.GetOrdinal("name")),
                    level = reader.GetString(reader.GetOrdinal("level"))
                });
            }

            return teams;
        }
    }
}
