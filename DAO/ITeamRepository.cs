using IPLApplication.Models;

namespace IPLApplication.DAO
{
    public interface ITeamRepository
    {
        List<Team> GetTeams();
    }
}