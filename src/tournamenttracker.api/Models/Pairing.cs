using System.ComponentModel.DataAnnotations;

namespace TournamentWebApp.Models
{
    public class Pairing
    {
        public int Id { get; set; }
        public int Round;
        public int P1Id { get; set; }
        public int P2Id { get; set; }
        [Required]
        public int P1Score { get; set; }
        [Required]
        public int P2Score { get; set; }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }
}