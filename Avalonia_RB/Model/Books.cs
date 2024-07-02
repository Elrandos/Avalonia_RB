using System.ComponentModel.DataAnnotations;
using Avalonia_RB.Enums;

namespace Avalonia_RB.Model
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public BookCategory BookCategory { get; set; }
        public bool IsAvailable { get; set; }
    }
}
