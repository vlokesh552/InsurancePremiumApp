using InsuranceApp.Models;
using InsurancePremiumApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<OccupationRating> OccupationRatings { get; set; }
        public DbSet<UserPremium> UserPremiums { get; set; }

    }
}
