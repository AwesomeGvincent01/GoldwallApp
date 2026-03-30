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




            var rooms = new Room[]
            {
                new Room
                {
                    JobId = jobs[0].JobId,
                    Name = "Lounge",
                    Notes = "Main living area"
                },
                new Room
                {
                    JobId = jobs[0].JobId,
                    Name = "Hallway",
                    Notes = "Connecting hallway"
                },
                new Room
                {
                    JobId = jobs[1].JobId,
                    Name = "Bedroom 1",
                    Notes = "Repair work area"
                }
            };




            foreach (var room in rooms)
            {
                context.Rooms.Add(room);
            }
            context.SaveChanges();





            var surfaces = new Surface[]
            {
                new Surface
                {
                    RoomId = rooms[0].RoomId,
                    SurfaceType = "Wall",
                    Label = "North Wall",
                    AreaM2 = 12.50m,
                    SubstrateType = "Plasterboard",
                    Notes = "Main feature wall"
                },
                new Surface
                {
                    RoomId = rooms[0].RoomId,
                    SurfaceType = "Ceiling",
                    Label = "Lounge Ceiling",
                    AreaM2 = 18.75m,
                    SubstrateType = "Plasterboard",
                    Notes = "Requires smooth finish"
                },
                new Surface
                {
                    RoomId = rooms[1].RoomId,
                    SurfaceType = "Wall",
                    Label = "Hallway Left Wall",
                    AreaM2 = 9.20m,
                    SubstrateType = "Old Plaster",
                    Notes = "Minor surface inconsistencies"
                },
                new Surface
                {
                    RoomId = rooms[2].RoomId,
                    SurfaceType = "Wall",
                    Label = "Bedroom East Wall",
                    AreaM2 = 10.40m,
                    SubstrateType = "Concrete",
                    Notes = "Repair area"
                }
            };








            foreach (var surface in surfaces)
            {
                context.Surfaces.Add(surface);
            }
            context.SaveChanges();




            var eventTypes = new EventType[]
  {
    new EventType
    {
        Name = "Inspection",
        Categoery = "Preparation",
        IsActive = true,
        BusinessId = businesses[0].BusinessId
    },
    new EventType
    {
        Name = "Surface Preparation",
        Categoery = "Preparation",
        IsActive = true,
        BusinessId = businesses[0].BusinessId
    },
    new EventType
    {
        Name = "First Coat",
        Categoery = "Application",
        IsActive = true,
        BusinessId = businesses[0].BusinessId
    }
  };

            foreach (var eventType in eventTypes)
            {
                context.EventTypes.Add(eventType);
            }
            context.SaveChanges();












            var workEvents = new WorkEvent[]
{
    new WorkEvent
    {
        SurfaceId = surfaces[0].SurfaceId,
        UserId = users[1].UserId,
        EventTypeId = eventTypes[0].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-01T09:00:00"),
        EndedAt = DateTime.Parse("2026-04-01T10:30:00"),
        Notes = "Initial inspection of north wall surface."
    },
    new WorkEvent
    {
        SurfaceId = surfaces[0].SurfaceId,
        UserId = users[1].UserId,
        EventTypeId = eventTypes[1].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-02T08:00:00"),
        EndedAt = DateTime.Parse("2026-04-02T12:00:00"),
        Notes = "Surface preparation including sanding and cleaning."
    },
    new WorkEvent
    {
        SurfaceId = surfaces[0].SurfaceId,
        UserId = users[1].UserId,
        EventTypeId = eventTypes[2].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-03T08:00:00"),
        EndedAt = DateTime.Parse("2026-04-03T17:00:00"),
        Notes = "Applied first coat of plaster to north wall."
    }
};

            foreach (var workEvent in workEvents)
            {
                context.WorkEvents.Add(workEvent);
            }
            context.SaveChanges();



            var materials = new Material[] {
                new Material
                {
                    MaterialId = 1,
                    BusinessId = 1,
                    Brand = "PlasterPro",
                    ProductName = "All-in-One Plaster",
                    MaterialType = "Plaster",
                    Notes = "Used for all plastering work on the north wall."
                },
                new Material
                {
                    MaterialId = 2,
                    BusinessId = 1,
                    Brand = "SanderMax",
                    ProductName = "Premium Sandpaper",
                    MaterialType = "Abrasive",
                    Notes = "Used for surface preparation before plastering."
                },
                new Material
                {
                    MaterialId = 3,
                    BusinessId = 1,
                    Brand = "CleanSurface",
                    ProductName = "Surface Cleaner",
                    MaterialType = "Cleaning",
                    Notes = "Used to clean the surface before plastering."
                }

            };

       foreach(var material in materials) {
                context.Materials.Add(material);

            }
       context.SaveChanges();








        }
    }
}