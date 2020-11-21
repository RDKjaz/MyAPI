using System.ComponentModel.DataAnnotations;

namespace MyApi.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int Id { get; set; }
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