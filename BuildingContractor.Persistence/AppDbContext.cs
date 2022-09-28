using Microsoft.EntityFrameworkCore;
using BuildingContractor.Application.Interfaces;
using BuildingContractor.Domain;
using BuildingContractor.Persistence.EntityTypeConfigurations;

namespace BuildingContractor.Persistence
{
    public class AppDbContext : DbContext, INotesDbContext
    {
        public DbSet<Customer> customers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
