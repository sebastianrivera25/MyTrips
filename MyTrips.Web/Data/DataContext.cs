using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTrips.Web.Data.Entities;

namespace MyTrips.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<ExpenseEntity> Expenses { get; set; }
        public DbSet<ExpenseTypeEntity> ExpenseTypes { get; set; }
        public DbSet<TripEntity> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ExpenseTypeEntity>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}
