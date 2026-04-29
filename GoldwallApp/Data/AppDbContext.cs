using GoldwallApp.Areas.Identity.Data;
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

        public DbSet<EventOutcome> EventOutcomes { get; set; }  

        public DbSet<EventContext> EventContexts { get; set; }

        public DbSet<DefectReport> DefectReports { get; set; }

        public DbSet<DefectType> DefectTypes { get; set; }

        public DbSet<EvidencePhoto> EvidencePhotos { get; set; }

        public DbSet<Pattern> Patterns { get; set; }

        public DbSet<PatternRule> PatternRules { get; set; }    
        
        public DbSet<PatternOutcome> PatternOutcomes { get; set; }  

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
            modelBuilder.Entity <EvidencePhoto>().ToTable("EvidencePhoto"); 
            modelBuilder.Entity<Pattern>().ToTable("Pattern");
            modelBuilder.Entity<PatternRule>().ToTable("PatternRule");
            modelBuilder.Entity<PatternOutcome>().ToTable("PatternOutcome");




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


            //new

            modelBuilder.Entity<EventContext>()
                .Property(ec => ec.ThicknessMm)
                .HasPrecision(5, 2);

            modelBuilder.Entity<EventContext>()
                .Property (ec => ec.HumidityPct)
                .HasPrecision (5, 2);


            modelBuilder.Entity<EventContext>()
                .Property(ec => ec.TemperatureC)
                .HasPrecision(5, 2);

            modelBuilder.Entity<EventContext>()
                .Property(ec => ec.TimeSincePrevEventHours)
                .HasPrecision(5, 2);

            

            modelBuilder.Entity<EventOutcome>()
                .Property (eo => eo.DryTimeHoursActual)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Pattern>()
                .Property(p => p.Confidence)
                .HasPrecision(5, 2);

            modelBuilder.Entity<PatternOutcome>()
                .Property(po => po.Probability)
                .HasPrecision(4, 2);

        }
        public DbSet<GoldwallApp.Models.EventOutcome> EventOutcome { get; set; } = default!;
       
        
    }
}