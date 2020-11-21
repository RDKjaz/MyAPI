using System.ComponentModel.DataAnnotations;

namespace MyApi.Dtos
{
    public class GradeUpdateDto
    {
        [Required]
        public int CourseGrade { get; set; }
    }
}