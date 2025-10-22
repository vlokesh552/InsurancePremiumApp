using InsuranceApp.Data;
using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Note: The SQL Server DB connection is temporarily commented out for testing purposes.
// Currently using InMemoryDatabase for rapid development and testing.
builder.Services.AddDbContext<ApplicationDbContext>(static options =>
    options.UseInMemoryDatabase("InsuranceDb"));

//// Add DB Context -- Uncomment to use SQL Server
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PremiumService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    var ratings = new List<OccupationRating>
    {
        new() { Id=1, RatingName="Professional", Factor=1.5M },
        new() { Id=2, RatingName="White Collar", Factor=2.25M },
        new() { Id=3, RatingName="Light Manual", Factor=1.50M },
        new() { Id=4, RatingName="Heavy Manual", Factor=3.75M },
    };
    db.OccupationRatings.AddRange(ratings);

    db.Occupations.AddRange(new[]
    {
        new Occupation{ Id=1, Name="Cleaner", RatingId=3 },
        new Occupation{ Id=2, Name="Doctor", RatingId=1 },
        new Occupation{ Id=3, Name="Author", RatingId=2 },
        new Occupation{ Id=4, Name="Farmer", RatingId=4 },
        new Occupation{ Id=5, Name="Mechanic", RatingId=4 },
        new Occupation{ Id=6, Name="Florist", RatingId=3 },
        new Occupation{ Id=7, Name="Other", RatingId=4 }
    });

    db.SaveChanges();
}

app.Run();
