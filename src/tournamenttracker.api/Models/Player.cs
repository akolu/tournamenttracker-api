using System.ComponentModel.DataAnnotations;

namespace TournamentWebApp.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
    }
}