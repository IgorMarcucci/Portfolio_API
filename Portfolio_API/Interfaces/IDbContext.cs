using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public interface IDbContext
{
    DbSet<JobModel> Jobs { get; set; }
    DbSet<LangModel> Langs { get; set; }
    DbSet<LanguageModel> Languages { get; set; }
    DbSet<ProjectModel> Projects { get; set; }
    DbSet<TechModel> Techs { get; set; }
    DbSet<TopicModel> Topics { get; set; }
    int SaveChanges();
}
