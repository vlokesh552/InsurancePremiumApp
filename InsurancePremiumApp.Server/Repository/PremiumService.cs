using InsuranceApp.Data;
using InsuranceApp.Models;
using InsurancePremiumApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Repository
{
    public class PremiumService
    {
        private readonly ApplicationDbContext _context;

        public PremiumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> CalculatePremiumAsync(PremiumRequest request)
        {
            var occupation = await _context.Occupations
                .Include(o => o.Rating)
                .FirstOrDefaultAsync(o => o.Id == request.OccupationId);

            if (occupation == null)
                throw new Exception("Invalid Occupation");

            decimal ratingFactor = occupation.Rating.Factor;

            decimal premiumAmount = (request.DeathSumInsured * ratingFactor * request.Age) / (1000 * 12);
            
            //Logic to log the data into the database
            //var userPremium = new UserPremium
            //{
            //    UserName = request.UserName,
            //    Age = request.Age,
            //    DateOfBirth = request.DateOfBirth,
            //    DeathSumInsured = request.DeathSumInsured,
            //    OccupationId = request.OccupationId,
            //    MonthlyPremium = Math.Round(premiumAmount, 4)
            //};
            //_context.UserPremiums.Add(userPremium);
            //await _context.SaveChangesAsync();

            return Math.Round(premiumAmount, 4);
        }

        public async Task<List<Occupation>> GetOccupationsAsync()
        {
            return await _context.Occupations.Include(o => o.Rating).ToListAsync();
        }
    }
}
