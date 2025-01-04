using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurveyBasket.Persistence.EntitiesConfigurations;

namespace SurveyBasket.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : 
    IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Poll> Polls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        // Create a hasher to hash the password
        var passwordHasher = new PasswordHasher<ApplicationUser>();

        // Seed a user
        var user = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "johndoe",
            NormalizedUserName = "JOHNDOE",
            Email = "johndoe@example.com",
            NormalizedEmail = "JOHNDOE@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            FirstName = "John",
            LastName = "Doe"
        };

        // Hash the password "Test@123" and set it
        user.PasswordHash = passwordHasher.HashPassword(user, "Test@123");

        // Add user to the database
        modelBuilder.Entity<ApplicationUser>().HasData(user);
    }
}
