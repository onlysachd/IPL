using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IPLApplication.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public string Venue { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public string Winner { get; set; }
    }
}


















