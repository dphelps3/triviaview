using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaLink.Models
{
    public class Game
    {
        public int GameID { get; set; }

        [Display(Name = "Code")]
        public string? GameCode { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime GameDay { get; set; }

        [Display(Name = "Format")]
        public int GameFormat { get; set; }

        [Display(Name = "Theme")]
        public string GameTheme { get; set; } = string.Empty;

        [Display(Name = "Location")]
        public string GameLocation { get; set; } = string.Empty;

        [Display(Name = "Trivia Master First Name")]
        public string MasterFirstName { get; set; } = string.Empty;

        [Display(Name = "Trivia Master Last Name")]
        public string MasterLastName { get; set; } = string.Empty;
    }
}
