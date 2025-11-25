using System.ComponentModel.DataAnnotations;

namespace STUDENTPortal.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string StudentId { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Please enter valid email")]
        public string Email { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public DateOnly RegistrationDate { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
