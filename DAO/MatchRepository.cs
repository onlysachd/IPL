using IPLApplication.DAO;
using IPLApplication.Models;
using Npgsql;
using System.Data.Common;
using System.Data;

namespace IPLApplication.DAO
{
    public class MatchRepository : IMatchRepository
    {
        private readonly string _connectionString;

        public MatchRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgreDB");
        }

        public List<Match> GetMatchesByDateRange(DateTime startDate, DateTime endDate)
        {
            var matches = new List<Match>();
            using (var connection = new NpgsqlCommand(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    @"SELECT MatchId, MatchDate, Venue, Team1Id, Team2Id, Winner 
                      FROM Matches 
                      WHERE MatchDate BETWEEN @StartDate AND @EndDate", connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matches.Add(new Match
                        {
                            MatchId = reader.GetInt32(0),
                            MatchDate = reader.GetDateTime(1),
                            Venue = reader.GetString(2),
                            Team1Id = reader.GetInt32(3),
                            Team2Id = reader.GetInt32(4),
                            Winner = reader.GetString(5)
                        });
                    }
                }
            }

            return matches;
        }

        public List<Match> GetMatchDetails()
        {
            var matches = new List<Match>();
            using (var connection = new NpgsqlCommand(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    @"SELECT m.MatchId, m.MatchDate, m.Venue, t1.TeamName as Team1, t2.TeamName as Team2, COUNT(e.EngagementId) as TotalEngagements 
                      FROM Matches m
                      JOIN Teams t1 ON m.Team1Id = t1.TeamId
                      JOIN Teams t2 ON m.Team2Id = t2.TeamId
                      LEFT JOIN Fan_Engagement e ON m.MatchId = e.MatchId
                      GROUP BY m.MatchId, m.MatchDate, m.Venue, t1.TeamName, t2.TeamName", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matches.Add(new Match
                        {
                            MatchId = reader.GetInt32(0),
                            MatchDate = reader.GetDateTime(1),
                            Venue = reader.GetString(2),
                            Team1Id = reader.GetInt32(3),
                            Team2Id = reader.GetInt32(4)
                        });
                    }
                }
            }

            return matches;
        }
    }
}
