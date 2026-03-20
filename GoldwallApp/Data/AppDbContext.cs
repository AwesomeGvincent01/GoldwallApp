using GoldwallApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldwallApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Business> Businesses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Surface> Surfaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>().ToTable("Business");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Job>().ToTable("Job");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Surface>().ToTable("Surface");
        }
    }
}