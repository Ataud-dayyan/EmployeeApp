using Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class CreateEmployeeViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public Guid DepartmentId { get; set; } // Foreign key to Department

        // You can add a list of departments to populate a dropdown
        public List<DepartmentDto> Departments { get; set; }
    }
}
