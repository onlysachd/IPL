using IPLApplication.Models;

namespace IPLApplication.DAO
{
    public interface IPlayerRepository
    {
        void AddPlayer(Player player);
        List<Player> GetTopPlayers();
    }
}