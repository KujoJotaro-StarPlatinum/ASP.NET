using System.ComponentModel.DataAnnotations;

namespace ASPNETProdactAndCategory.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Student should have a name")]
        [MinLength(5, ErrorMessage = "Should have a minimum 5 chars")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}