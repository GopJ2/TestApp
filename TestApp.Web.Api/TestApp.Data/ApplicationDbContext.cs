using Microsoft.EntityFrameworkCore;
using TestApp.Data.Entity.Tests;
using TestApp.Data.Entity.Users;
using TestApp.Data.Mappers;
using TestApp.Data.Seeders;

namespace TestApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string _connection { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestAnswer> Answers { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public ApplicationDbContext(string connectionString)
        {
            _connection = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddMappers();
            modelBuilder.SeedDataBase();
        }
    }
}
