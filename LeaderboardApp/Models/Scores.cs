using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaderboardApp.Models
{
    public class Scores
    {
        [Key]
        public int ScoreID { get; set; }
        public int Score { get; set; }

        [ForeignKey("Songs")]
        public int SongID { get; set; }

        [ForeignKey("Users")]
        public int UsersId { get; set; }

        public Users Users { get; set; } = null!;
        public Songs Songs { get; set; } = null!;
    }
}
