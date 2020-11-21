using System.ComponentModel.DataAnnotations;

namespace MyApi.Models
{
    public class Course
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Lecturer { get; set; }
    }
}
