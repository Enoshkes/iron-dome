using IronDome.Models;
using Microsoft.EntityFrameworkCore;

namespace IronDome.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,IConfiguration configuration
        ) : base (options)
        {
            _configuration = configuration;
            Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<AdminModel> Admin {  get; set; }
        public DbSet<ThreatModel> Threat { get; set; }

        private void Seed() 
        {
            if (!Admin.Any())
            {
                AdminModel model = new() { MissileAmount = 200 };
                Admin.Add(model);
                SaveChanges();
            }
        }

    }
}
