using Microsoft.EntityFrameworkCore;

namespace Portfolio_API;

public interface IDbContext
{
    DbSet<JobModel> Jobs { get; set; }
    DbSet<LangModel> Langs { get; set; }
    int SaveChanges();
}
