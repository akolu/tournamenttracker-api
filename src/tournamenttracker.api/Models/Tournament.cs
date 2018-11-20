using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TournamentWebApp.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Round> Rounds { get; set; }
    }
}