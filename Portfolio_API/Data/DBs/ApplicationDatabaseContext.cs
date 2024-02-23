using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public class ApplicationDatabaseContext : DbContext, IDbContext
{

    private readonly IConfiguration _configuration;

    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> opt, IConfiguration configuration) : base(opt)
    {
        _configuration = configuration;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string? adminEmail = _configuration.GetValue<string>("adminEmail");
            string? adminPassword = _configuration.GetValue<string>("adminPassword");

            UserModel admin = new UserModel
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = adminEmail,
                NormalizedEmail = adminEmail?.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 1,
            };
            PasswordHasher<UserModel> hasher = new PasswordHasher<UserModel>();
            admin.PasswordHash = hasher.HashPassword(admin, adminPassword!);

            modelBuilder.Entity<UserModel>().HasData(admin);

            // modelBuilder.Entity<UserModel>()
            //     .HasMany(u => u.Jobs).WithOne(j => j.User).HasForeignKey(j => j.UserId);
            
            // modelBuilder.Entity<JobModel>()
            //     .HasMany(j => j.Langs);
        }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<JobModel> Jobs { get; set; }
    public DbSet<LangModel> Langs { get; set; }
}
