using IPLApplication.DAO;
using IPLApplication.Models;
using Npgsql;

namespace IPLApplication.DAO
{
    public class TeamRepository : ITeamRepository
    {
        private readonly string _connectionString;

        public TeamRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Team> GetTeams()
        {
            var teams = new List<Team>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand(
                    "SELECT TeamId, TeamName FROM Teams", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teams.Add(new Team
                        {
                            TeamId = reader.GetInt32(0),
                            TeamName = reader.GetString(1)
                        });
                    }
                }
            }

            return teams;
        }
    }
}