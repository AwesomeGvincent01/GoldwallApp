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
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<WorkEvent> WorkEvents { get; set; }

        public DbSet<Material> Materials { get; set; }


        public DbSet<EventContext> EventContexts { get; set; }

        public DbSet<DefectReport> DefectReports { get; set; }

        public DbSet<DefectReport> DefectTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>().ToTable("Business");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Job>().ToTable("Job");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Surface>().ToTable("Surface");
            modelBuilder.Entity<EventType>().ToTable("EventType");
            modelBuilder.Entity<WorkEvent>().ToTable("WorkEvent");
            modelBuilder.Entity<Material>().ToTable("Material");
            modelBuilder.Entity<EventContext>().ToTable("EventContext");
            modelBuilder.Entity<DefectReport>().ToTable("DefectReport");
            modelBuilder.Entity<DefectType>().ToTable("DefectType");

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

            modelBuilder.Entity<EventType>()
                .HasOne(e => e.Business)
                .WithMany(b => b.EventTypes)
                .HasForeignKey(e => e.BusinessId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkEvent>()
                .HasOne(w => w.Surface)
                .WithMany(s => s.WorkEvents)
                .HasForeignKey(w => w.SurfaceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkEvent>()
                .HasOne(w => w.User)
                .WithMany(u => u.WorkEvents)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkEvent>()
                .HasOne(w => w.EventType)
                .WithMany(e => e.WorkEvents)
                .HasForeignKey(w => w.EventTypeId)
                .OnDelete(DeleteBehavior.Restrict);



            //n tl
            modelBuilder.Entity<Material>()
                .HasOne(m => m.Business)
                .WithMany(b => b.Materials)
                .HasForeignKey(m => m.BusinessId)
                .OnDelete(DeleteBehavior.Restrict);
        }
       
        
    }
}