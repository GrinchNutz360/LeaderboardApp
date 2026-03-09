using LeaderboardApp.Data.Interfaces;
using LeaderboardApp.Models;

namespace LeaderboardApp.Data.Services
{
    public class ScoreDbService : IScoreable
    {
        public ScoreDbContext context { get; set; }
        public void AddScore(Scores score)
        {
            context.Scores.Add(score);
            context.SaveChanges();
        }

        public IEnumerable<Scores> GetAllScores()
        {
            return context.Scores;
        }

        public IEnumerable<Songs> GetAllSongs()
        {
            return context.Songs;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return context.Users;
        }

        public Scores? RemoveScore(int id)
        {
            Scores selected = GetAllScores().FirstOrDefault(dih => dih.ID == id)!;
            context.Remove(selected);
            context.SaveChanges();

            return selected;
        }
    }
}
