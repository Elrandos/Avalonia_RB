using System;
using System.ComponentModel.DataAnnotations;
using Avalonia_RB.Model.Dto;

namespace Avalonia_RB.Model
{
    public class CheckOuts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        public Books Book { get; set; }
        public UserDto User { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
