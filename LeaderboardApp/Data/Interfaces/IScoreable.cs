using LeaderboardApp.Models;

namespace LeaderboardApp.Data.Interfaces
{
    public interface IScoreable
    {
        IEnumerable<Scores> GetAllScores();
        IEnumerable<Users> GetAllUsers();
        IEnumerable<Songs> GetAllSongs();
        
        void AddScore(Scores score);
        Scores? RemoveScore(int id);
    }
}
