using LeaderboardApp.Data.Interfaces;
using LeaderboardApp.Models;

namespace LeaderboardApp.Data.Services
{
    public class ScoreDbService : IScoreable
    {
        private readonly ScoreDbContext _context;

        public ScoreDbService(ScoreDbContext context)
        {
            _context = context;
        }

        public void AddScore(Scores score)
        {
            _context.Scores.Add(score);
            _context.SaveChanges();
        }

        public IEnumerable<Scores> GetAllScores()
        {
            return _context.Scores;
        }

        public IEnumerable<Songs> GetAllSongs()
        {
            return _context.Songs;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _context.Users;
        }

        public Scores? RemoveScore(int id)
        {
            Scores selected = GetAllScores().FirstOrDefault(s => s.ScoreID == id)!;
            _context.Remove(selected);
            _context.SaveChanges();
            return selected;
        }
    }
}
