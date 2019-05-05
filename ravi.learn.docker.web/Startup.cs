using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ravi.learn.docker.web.Data;

namespace ravi.learn.docker.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var dbServer = Configuration["DB_Server"];
            var dbPassword = Configuration["DB_Pwd"];
            var dbUserId  = Configuration["DB_UserId"];

            var connectionString = Configuration["ConnectionStrings:MagsConnectionAzMsSql"];

            services.AddDbContext<MagContext>(options => options.UseSqlServer(connectionString.Replace("{ENVDBID}", dbUserId).Replace("{ENVDBPWD}", dbPassword).Replace("{ENVSRV}", dbServer)));
                   //options.UseSqlServer(Configuration.GetConnectionString("MagsConnectionAzMsSql")));

            //  services.AddDbContext<MagContext>(options =>
            //          options.UseSqlite(Configuration.GetConnectionString("MagsConnectionSqlLite")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
