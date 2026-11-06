using Domain.DTO_s;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repo
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _connectionString;

        public MemberRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Member AuthenticateMember(string email, string password)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);

            string sql = @"
        SELECT id, name, email, passwordHash, Role
        FROM Member
        WHERE email = @email
        AND passwordHash = @password";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Member
                {
                    id = Convert.ToInt32(reader["id"]),
                    name = reader["name"].ToString(),
                    email = reader["email"].ToString(),
                    passwordHash = reader["passwordHash"].ToString(),
                    Role = (Role)Convert.ToInt32(reader["Role"])
                };
            }

            return null;
        }

        public Player GetPlayerByMemberId(int memberId)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);

            string sql = @"
        SELECT *
        FROM Player
        WHERE MemberId = @MemberId";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MemberId", memberId);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Player
                {
                    id = Convert.ToInt32(reader["id"]),
                    MemberID = Convert.ToInt32(reader["MemberID"])
                };
            }

            return null;
        }

    }
}
