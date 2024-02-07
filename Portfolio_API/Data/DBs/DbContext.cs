using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Portfolio_API;

public class ApplicationDatabaseContext : DbContext, IDbContext
{
    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> opt) : base(opt)
    {

    }
    
    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var webApplicationBuilder = WebApplication.CreateBuilder();
            string? adminEmail = webApplicationBuilder.Configuration.GetValue<string>("adminEmail");;
            string? adminPassword = webApplicationBuilder.Configuration.GetValue<string>("adminPassword");;

            IdentityUser<int> admin = new IdentityUser<int>
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 2,
            };
            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();
            admin.PasswordHash = hasher.HashPassword(admin, adminPassword);

            builder.Entity<IdentityUser<int>>().HasData(admin);

            builder.Entity<UserModel>()
                .HasMany(u => u.Jobs);
            
            builder.Entity<JobModel>()
                .HasMany(j => j.Langs);

        }

    public DbSet<JobModel> Jobs { get; set; }
    public DbSet<LangModel> Langs { get; set; }
}
