using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ravi.learn.docker.web.Data;
using ravi.learn.docker.web.Extensions;

namespace ravi.learn.docker.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build()
                    .MigrateDatabase<MagContext>().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
