using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using bilet1;
using Npgsql;

namespace bilet1;
public static class DatabaseHelper
{
    private static string connectionString = "Host=localhost;Username=postgres;Password=123;Database=postgres;SearchPath=bilet1";

    public static List<Circles> GetCircles()
    {
        var circles = new List<Circles>();
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        string sql = "select circle_id, circle_name, education_level from circles";
        using var cmd = new NpgsqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            circles.Add(new Circles
            {
                CircleId = reader.GetInt32(0),
                CircleName = reader.GetString(1),
                EducationLevel = reader.GetString(2)
            });
        }

        return circles;
    }

    public static List<Leaders> GetLeaders()
    {
        var leaders = new List<Leaders>();
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        string sql = @"select leader_id, full_name, circle_name from 
        leaders left join circles on circles.circle_id = leaders.circle_id";

        using var cmd = new NpgsqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            leaders.Add(new Leaders
            {
               LeaderId = reader.GetInt32(0),
               FullName = reader.GetString(1),
               CircleName = reader.GetString(2) 
            });
        }
        return leaders;
    }


    public static void InsertVisit(int leaderId, DateTime visitDate, int childerCount)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        string sql = @"insert into visits (leader_id, visit_date, children_count) values
            (@leader_id, @visit_date, @children_count)";

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@leader_id", leaderId);
        cmd.Parameters.AddWithValue("@visit_date", visitDate); 
        cmd.Parameters.AddWithValue("@children_count", childerCount);
        cmd.ExecuteNonQuery();
    }


    public static Leaders GetLeaderByName(string leaderName)
    {
        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        string sql = @"select leader_id, full_name, circle_id from leaders where full_name = @full_name";
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@full_name", leaderName);
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            return new Leaders
            {
                LeaderId = reader.GetInt32(0),
                FullName = reader.GetString(1),
                CircleId = reader.GetInt32(2)
            };
        }
        return null;
    } 
}