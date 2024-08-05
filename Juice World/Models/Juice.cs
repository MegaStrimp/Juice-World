using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juice_World.Models
{
    public class Juice
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Display(Name = "Release Date"), DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), StringLength(30)]
        [Required]
        public string? Genre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
        [Required]
        public string? Rating { get; set; }

        [Range(1, 100), DataType(DataType.Currency)]
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        // The '?' indicates that the property is nullable
    }
}
