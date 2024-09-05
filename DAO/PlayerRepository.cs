using IPLApplication.Models;
using IPLApplication.DAO;
using System.Data.SqlClient;
using Npgsql;

namespace IPLApplication.DAO
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly string _connectionString;

        public PlayerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddPlayer(Player player)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "INSERT INTO Players (PlayerName, TeamId) VALUES (@PlayerName, @TeamId)", connection);
                command.Parameters.AddWithValue("@PlayerName", player.PlayerName);
                command.Parameters.AddWithValue("@TeamId", player.TeamId);

                command.ExecuteNonQuery();
            }
        }

        public List<Player> GetTopPlayers()
        {
            var players = new List<Player>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    @"SELECT TOP 5 p.PlayerId, p.PlayerName, COUNT(m.MatchId) as MatchesPlayed 
                      FROM Players p 
                      JOIN Matches m ON p.TeamId = m.Team1Id OR p.TeamId = m.Team2Id
                      JOIN Fan_Engagement e ON m.MatchId = e.MatchId
                      GROUP BY p.PlayerId, p.PlayerName
                      ORDER BY COUNT(m.MatchId) DESC", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(new Player
                        {
                            PlayerId = reader.GetInt32(0),
                            PlayerName = reader.GetString(1)
                        });
                    }
                }
            }

            return players;
        }
    }
}
