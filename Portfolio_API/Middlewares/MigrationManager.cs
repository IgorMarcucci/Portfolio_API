using Microsoft.EntityFrameworkCore;

namespace Portfolio_API
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();
            try
            {
                appContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
                
            return app;
        }
    }
}
