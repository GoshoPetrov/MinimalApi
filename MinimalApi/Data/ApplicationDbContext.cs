using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Geography> Geographies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Geography>().HasData(
                new Geography
                {
                    Id = 1,
                    Key = "country",
                    Value = "Bulgaria"
                },
                new Geography
                {
                    Id = 2,
                    Key = "country",
                    Value = "Germany"
                },
                new Geography
                {
                    Id = 3,
                    Key = "country",
                    Value = "France"
                },
                new Geography
                {
                    Id = 4,
                    Key = "city",
                    Value = "Sofia"
                },
                new Geography
                {
                    Id = 5,
                    Key = "city",
                    Value = "Berlin"
                },
                new Geography
                {
                    Id = 6,
                    Key = "city",
                    Value = "Paris"
                },
                new Geography
                {
                    Id = 7,
                    Key = "region",
                    Value = "Sofia City Province"
                },
                new Geography
                {
                    Id = 8,
                    Key = "region",
                    Value = "Bavaria"
                }
            );
        }
    }
}
