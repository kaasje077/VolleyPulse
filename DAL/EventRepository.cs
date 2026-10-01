using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Logic.DTO_s;
using Logic.Interfaces;

namespace DAL
{
    public class EventRepository : IEventRepository
    {
        private readonly string _connectionString;

        public EventRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreatePractice(Event newEvent, TimeSpan endTime)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(
                @"INSERT INTO Event ([date], startTime, location, notes, AdminID)
                OUTPUT INSERTED.id
                VALUES (@date, @startTime, @location, @notes, @AdminID)",
                conn);

            cmd.Parameters.AddWithValue("@date", newEvent.date);
            cmd.Parameters.AddWithValue("@startTime", newEvent.startTime);
            cmd.Parameters.AddWithValue("@location", newEvent.location);
            cmd.Parameters.AddWithValue("@notes", (object?)newEvent.notes ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AdminID", newEvent.AdminID);

            int eventId = (int)cmd.ExecuteScalar();

            var practiceCmd = new SqlCommand(
                @"INSERT INTO Practice (EventID, endTime)
                VALUES (@EventID, @endTime)",
                conn);

            practiceCmd.Parameters.AddWithValue("@EventID", eventId);
            practiceCmd.Parameters.AddWithValue("@endTime", endTime);

            practiceCmd.ExecuteNonQuery();
        }


        public List<Practice> GetAllPractices()
        {
            var practices = new List<Practice>();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            var cmd = new SqlCommand(
                @"SELECT e.*, p.endTime
          FROM Event e
          INNER JOIN Practice p
              ON e.id = p.EventID",
                conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                practices.Add(new Practice
                {
                    id = (int)reader["id"],
                    date = (DateTime)reader["date"],
                    startTime = (TimeSpan)reader["startTime"],
                    location = (string)reader["location"],
                    notes = reader["notes"] == DBNull.Value
                        ? null
                        : (string)reader["notes"],
                    AdminID = (int)reader["AdminID"],

                    EventID = (int)reader["id"],
                    endTime = (TimeSpan)reader["endTime"]
                });
            }

            return practices;
        }
    }
}
