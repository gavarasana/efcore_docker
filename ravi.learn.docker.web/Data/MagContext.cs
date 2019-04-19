using Microsoft.EntityFrameworkCore;
using ravi.learn.docker.web.Models;

namespace ravi.learn.docker.web.Data
{
    public class MagContext : DbContext
    {
        public MagContext (DbContextOptions<MagContext> options)
            : base(options)
        {
        }

        public DbSet<Magazine> Magazine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Magazine>().HasData(
                new Magazine { Id = 1, Name = "MSDN Magazine"},
                new Magazine { Id = 2, Name = "Docker Magazine"},
                new Magazine { Id = 3, Name = "EF Core Magazine"}
                );

            base.OnModelCreating(modelBuilder);

        }
    }
}
