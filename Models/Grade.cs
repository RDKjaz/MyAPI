using System.ComponentModel.DataAnnotations;

namespace MyApi.Models
{
    public class Grade
    {
        [Key]
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int CourseGrade { get; set; }
    }
}
