using GoldwallApp.Models;

namespace GoldwallApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
          
            context.Database.EnsureCreated();

         
            if (context.Businesses.Any())
            {
                return;
            }

        
            var businesses = new Business[]
            {
                new Business
                {
                    Name = "Goldwall Co. Limited",
                    CreatedAt = DateTime.Now
                }
            };

            foreach (var business in businesses)
            {
                context.Businesses.Add(business);
            }
            context.SaveChanges();

           
            var users = new User[]
            {
                new User
                {
                    BusinessId = businesses[0].BusinessId,
                    FullName = "Alan Admin",
                    Email = "alan@goldwall.local",
                    Role = "Admin",
                    PasswordHash = "demo_hash_1",
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    BusinessId = businesses[0].BusinessId,
                    FullName = "Site Recorder",
                    Email = "scribe@goldwall.local",
                    Role = "Recorder",
                    PasswordHash = "demo_hash_2",
                    CreatedAt = DateTime.Now
                }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

          
            var clients = new Client[]
            {
                new Client
                {
                    BusinessId = businesses[0].BusinessId,
                    Name = "John Smith",
                    Phone = "0210000001",
                    Email = "john@example.com",
                    CreatedAt = DateTime.Now
                },
                new Client
                {
                    BusinessId = businesses[0].BusinessId,
                    Name = "Sarah Builder",
                    Phone = "0210000002",
                    Email = "sarah@example.com",
                    CreatedAt = DateTime.Now
                }
            };

            foreach (var client in clients)
            {
                context.Clients.Add(client);
            }
            context.SaveChanges();

            // Seed jobs
            var jobs = new Job[]
            {
                new Job
                {
                    BusinessId = businesses[0].BusinessId,
                    ClientId = clients[0].ClientId,
                    Title = "Lounge and Hallway Plastering",
                    Address = "25 Example Street, Auckland",
                    Status = "Planned",
                    StartDatePlanned = DateTime.Parse("2026-04-01"),
                    EndDatePlanned = DateTime.Parse("2026-04-04"),
                    CreatedAt = DateTime.Now
                },
                new Job
                {
                    BusinessId = businesses[0].BusinessId,
                    ClientId = clients[1].ClientId,
                    Title = "Bedroom Surface Repair",
                    Address = "12 Sample Road, Auckland",
                    Status = "Active",
                    StartDatePlanned = DateTime.Parse("2026-04-06"),
                    EndDatePlanned = DateTime.Parse("2026-04-08"),
                    CreatedAt = DateTime.Now
                }
            };

            foreach (var job in jobs)
            {
                context.Jobs.Add(job);
            }
            context.SaveChanges();
        }
    }
}