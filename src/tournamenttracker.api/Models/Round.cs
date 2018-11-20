using System.Collections.Generic;

namespace TournamentWebApp.Models
{
    public class Round
    {
        public int RoundId { get; set; }

        public int Tournament { get; set; }

        public int RoundNumber { get; set; }

        public ICollection<Pairing> Pairings { get; set; }
    }
}