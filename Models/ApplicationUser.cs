using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Micheletti_Company.Models
{
    public class ApplicationUser : IdentityUser
    {
        // 1. FirstName (Mandatory)
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        // 2. LastName (Mandatory)
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        // 3. City 
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
        [Display(Name = "City")]
        public string? City { get; set; }
    }
}