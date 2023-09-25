using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaLink.Models
{
    public class Slide
    {
        public int SlideID { get; set; }
        public byte? SlideImage { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public int? GameID { get; set; }
    }
}
