using System.ComponentModel.DataAnnotations;

namespace MyApi.Dtos
{
    public class CourseCreateDto
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Lecturer { get; set; }
    }
}