using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Models
{
    public class PremiumRequest
    {
        [Required(ErrorMessage = "UserName is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "UserName must be between 2 and 100 characters.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required.")]
        [Range(0, 99, ErrorMessage = "Age must be between 0 and 99.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "DateOfBirth is required.")]
        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{4}-\d{2}", ErrorMessage = "DateOfBirth must be in YYYY-MM format.")]
        public string DateOfBirth { get; set; } = string.Empty;

        [Required(ErrorMessage = "OccupationId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "OccupationId must be a positive integer.")]
        public int OccupationId { get; set; }

        [Required(ErrorMessage = "DeathSumInsured is required.")]
        [Range(typeof(decimal), "1000", "100000000", ErrorMessage = "DeathSumInsured must be greater than 0.")]
        public decimal DeathSumInsured { get; set; }
    }
}
