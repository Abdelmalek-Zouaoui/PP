using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public enum ThesisType
    {
        Doctorat,
        Master
    }

    public class Thesis
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required, MaxLength(100)]
        public string Author { get; set; } // Corrected spelling of "Author"

        [Required]
        public ThesisType Type { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [MaxLength(500)]
        public string Keywords { get; set; }

        [Required]
        public string FilePath { get; set; } // Path to the PDF file

        // Foreign key for the User who added the thesis
        public int UserId { get; set; }

        // Navigation property for the User
        public User User { get; set; }
    }
}