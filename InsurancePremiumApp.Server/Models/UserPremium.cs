using InsuranceApp.Models;

namespace InsurancePremiumApp.Server.Models
{
    public class UserPremium
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string DateOfBirth { get; set; } = string.Empty;
        public decimal DeathSumInsured { get; set; }
        public int OccupationId { get; set; }
        public decimal MonthlyPremium { get; set; }
        public Occupation Occupation { get; set; }
    }
}
