using Logic.DTO_s;
using Logic.Interfaces;
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
            cmd.Parameters.AddWithValue("@status", attendance.status);
            cmd.Parameters.AddWithValue("@PlayerID", attendance.PlayerID);
            cmd.Parameters.AddWithValue("@EventID", attendance.EventID);

            cmd.ExecuteNonQuery();
        }
    }
}
