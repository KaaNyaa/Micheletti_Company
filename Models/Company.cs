using System.ComponentModel.DataAnnotations;

namespace Micheletti_Company.Models
{
    public class Company
    {
        // 1. Id (Mandatory - Primary Key)
        public int Id { get; set; }

        // 2. Name (Mandatory)
        [Required(ErrorMessage = "Company Name is required.")]
        [StringLength(200, ErrorMessage = "Company Name cannot exceed 200 characters.")]
        [Display(Name = "Company Name")]
        public string Name { get; set; } = string.Empty;

        // 3. YearsInBusiness (Mandatory)
        [Required(ErrorMessage = "Years in Business is required.")]
        [Range(1, 100, ErrorMessage = "Years in Business must be between 1 and 100.")]
        [Display(Name = "Years in Business")]
        public int YearsInBusiness { get; set; }

        // 4. Website (Mandatory)
        [Required(ErrorMessage = "Website URL is required.")]
        [StringLength(500, ErrorMessage = "Website URL cannot exceed 500 characters.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        [Display(Name = "Website")]
        public string Website { get; set; } = string.Empty;

        // 5. Province 
        [StringLength(50, ErrorMessage = "Province name cannot exceed 50 characters.")]
        [Display(Name = "Province/State")]
        public string? Province { get; set; }
    }
}