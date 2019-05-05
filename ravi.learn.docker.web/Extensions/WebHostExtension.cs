using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ravi.learn.docker.web.Extensions
{
    public static class WebHostExtension
    {
        public static IWebHost MigrateDatabase<T>(this IWebHost webHost) where T: DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var dbContext = serviceProvider.GetRequiredService<T>();
                    dbContext.Database.Migrate();
                } catch (Exception exception)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occurred while migrating the database");
                }
            }
            return webHost;
               
        }
    }
}
