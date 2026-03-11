using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaderboardApp.Models
{
    public class Songs
    {
        [Key]
        public int SongID { get; set; }
        [Required]
        public required string SongName { get; set; }
        [NotMapped]
        public string? SongArtist { get; set; }
        [NotMapped]
        public string? CoveredBy { get; set; }
    }
}
