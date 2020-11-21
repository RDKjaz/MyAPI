using System.ComponentModel.DataAnnotations;

namespace MyApi.Dtos
{
    public class StudentCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}