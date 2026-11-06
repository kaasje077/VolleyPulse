using Domain.DTO_s;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repo
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly string _connectionString;

        public AttendanceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void MarkAttendance(Attendance attendance)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(
                @"INSERT INTO Attendance
                (timeStamp, status, PlayerID, EventID)
                VALUES
                (@timeStamp, @status, @PlayerID, @EventID)",
                conn);

            cmd.Parameters.AddWithValue("@timeStamp", attendance.timeStamp);
            cmd.Parameters.AddWithValue("@status", attendance.Status);
            cmd.Parameters.AddWithValue("@PlayerID", attendance.PlayerID);
            cmd.Parameters.AddWithValue("@EventID", attendance.EventID);

            cmd.ExecuteNonQuery();
        }

        public Attendance GetAttendanceByPlayerAndEvent(int playerId, int eventId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand(
                @"SELECT *
                FROM Attendance
                WHERE PlayerID = @PlayerID AND EventID = @EventID",
                conn);
            cmd.Parameters.AddWithValue("@PlayerID", playerId);
            cmd.Parameters.AddWithValue("@EventID", eventId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Attendance
                {
                    id = Convert.ToInt32(reader["id"]),
                    timeStamp = Convert.ToDateTime(reader["timeStamp"]),
                    Status = (Domain.Enums.Status)Convert.ToInt32(reader["status"]),
                    PlayerID = Convert.ToInt32(reader["PlayerID"]),
                    EventID = Convert.ToInt32(reader["EventID"])
                };
            }
            return null;
        }
    }
}
