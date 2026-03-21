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

            modelBuilder.Entity<Surface>()
                .Property(s => s.AreaM2)
                .HasPrecision(6, 2);

       
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Business)
                .WithMany(b => b.Clients)
                .HasForeignKey(c => c.BusinessId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Business)
                .WithMany(b => b.Users)
                .HasForeignKey(u => u.BusinessId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Business)
                .WithMany(b => b.Jobs)
                .HasForeignKey(j => j.BusinessId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Client)
                .WithMany()
                .HasForeignKey(j => j.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Job)
                .WithMany(j => j.Rooms)
                .HasForeignKey(r => r.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Surface>()
                .HasOne(s => s.Room)
                .WithMany(r => r.Surfaces)
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}