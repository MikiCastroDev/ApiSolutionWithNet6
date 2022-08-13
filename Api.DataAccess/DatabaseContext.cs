using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Api.DataAccess.Contracts.Entities;

namespace Api.DataAccess
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Configuration.GetConnectionString("PlanetScale");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Tables
            builder.Entity<Order>().ToTable("Order");
            #endregion
            #region Properties
            #endregion
            #region Relations
            #endregion
        }
    }
}
