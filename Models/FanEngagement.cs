using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IPLApplication.Models
{
    public class FanEngagement
    {
        public int EngagementId { get; set; }
        public int MatchId { get; set; }
        public int FanId { get; set; }
    }
}