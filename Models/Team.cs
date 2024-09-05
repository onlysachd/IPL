using IPLApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IPLApplication.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}