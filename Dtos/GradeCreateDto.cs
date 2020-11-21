using System.ComponentModel.DataAnnotations;

namespace MyApi.Dtos
{
    public class GradeCreateDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int CourseGrade { get; set; }
    }
}