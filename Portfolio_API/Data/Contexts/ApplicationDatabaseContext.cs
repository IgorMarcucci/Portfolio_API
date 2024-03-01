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

        modelBuilder.Entity<TopicModel>()
            .HasMany(u => u.Techs).WithOne(j => j.Topic).HasForeignKey(j => j.TopicId);

        modelBuilder.Entity<JobModel>()
            .HasMany(u => u.Projects).WithOne(j => j.Job).HasForeignKey(j => j.JobId);
        
        modelBuilder.Entity<LanguageModel>()
            .HasMany(u => u.Projects).WithOne(j => j.Language).HasForeignKey(j => j.LanguageId);
        
        modelBuilder.Entity<LanguageModel>()
            .HasMany(u => u.Topics).WithOne(j => j.Language).HasForeignKey(j => j.LanguageId);
        
        modelBuilder.Entity<LangModel>()
            .HasMany(u => u.Topics).WithOne(j => j.Lang).HasForeignKey(j => j.LangId);

        modelBuilder.Entity<JobModel>()
            .HasOne(j => j.Language)
            .WithMany(l => l.Jobs)  
            .HasForeignKey(j => j.LanguageId);
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<JobModel> Jobs { get; set; }
    public DbSet<LangModel> Langs { get; set; }
    public DbSet<LanguageModel> Languages { get; set; }
    public DbSet<ProjectModel> Projects { get; set; }
    public DbSet<TechModel> Techs { get; set; }
    public DbSet<TopicModel> Topics { get; set; }
}
