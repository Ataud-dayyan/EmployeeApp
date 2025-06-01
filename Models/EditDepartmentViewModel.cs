using System.ComponentModel.DataAnnotations;
 
namespace Presentation.Models;

    public class EditDepartmentViewModel
    {
        public string? Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }
    }

