using GoldwallApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                },
                new Business
                {
                    Name = "North Shore Interior Finishes",
                    CreatedAt = DateTime.Now.AddDays(-12)
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
                  
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    BusinessId = businesses[0].BusinessId,
                    FullName = "Site Recorder",
                    Email = "scribe@goldwall.local",
                    Role = "Recorder",
                  
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    BusinessId = businesses[0].BusinessId,
                    FullName = "Marcus Plasterer",
                    Email = "marcus@goldwall.local",
                    Role = "Worker",
                   
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    BusinessId = businesses[1].BusinessId,
                    FullName = "Nina Supervisor",
                    Email = "nina@northshore.local",
                    Role = "Admin",
                 
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    BusinessId = businesses[1].BusinessId,
                    FullName = "Leo Finisher",
                    Email = "leo@northshore.local",
                    Role = "Worker",
                  
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
                },
                new Client
                {
                    BusinessId = businesses[0].BusinessId,
                    Name = "Emma Carter",
                    Phone = "0210000003",
                    Email = "emma@example.com",
                    CreatedAt = DateTime.Now
                },
                new Client
                {
                    BusinessId = businesses[1].BusinessId,
                    Name = "David Lee",
                    Phone = "0210000004",
                    Email = "david@example.com",
                    CreatedAt = DateTime.Now
                },
                new Client
                {
                    BusinessId = businesses[1].BusinessId,
                    Name = "Olivia Tran",
                    Phone = "0210000005",
                    Email = "olivia@example.com",
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
                },
                new Job
                {
                    BusinessId = businesses[0].BusinessId,
                    ClientId = clients[2].ClientId,
                    Title = "Kitchen Ceiling Reskim",
                    Address = "88 Harbour View Road, Auckland",
                    Status = "Completed",
                    StartDatePlanned = DateTime.Parse("2026-04-10"),
                    EndDatePlanned = DateTime.Parse("2026-04-12"),
                    CreatedAt = DateTime.Now
                },
                new Job
                {
                    BusinessId = businesses[1].BusinessId,
                    ClientId = clients[3].ClientId,
                    Title = "Office Wall Preparation",
                    Address = "5 Apollo Drive, Auckland",
                    Status = "Active",
                    StartDatePlanned = DateTime.Parse("2026-04-15"),
                    EndDatePlanned = DateTime.Parse("2026-04-18"),
                    CreatedAt = DateTime.Now
                },
                new Job
                {
                    BusinessId = businesses[1].BusinessId,
                    ClientId = clients[4].ClientId,
                    Title = "Bathroom Patch and Finish",
                    Address = "41 Ridge Lane, Auckland",
                    Status = "Planned",
                    StartDatePlanned = DateTime.Parse("2026-04-20"),
                    EndDatePlanned = DateTime.Parse("2026-04-22"),
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
                },
                new Room
                {
                    JobId = jobs[1].JobId,
                    Name = "Bedroom 2",
                    Notes = "Secondary room"
                },
                new Room
                {
                    JobId = jobs[2].JobId,
                    Name = "Kitchen",
                    Notes = "Ceiling reskim area"
                },
                new Room
                {
                    JobId = jobs[2].JobId,
                    Name = "Dining",
                    Notes = "Adjacent dining area"
                },
                new Room
                {
                    JobId = jobs[3].JobId,
                    Name = "Reception",
                    Notes = "Front office wall prep"
                },
                new Room
                {
                    JobId = jobs[3].JobId,
                    Name = "Meeting Room",
                    Notes = "Internal office room"
                },
                new Room
                {
                    JobId = jobs[4].JobId,
                    Name = "Bathroom",
                    Notes = "Patch and finish area"
                },
                new Room
                {
                    JobId = jobs[4].JobId,
                    Name = "Laundry",
                    Notes = "Small adjoining space"
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
                },
                new Surface
                {
                    RoomId = rooms[2].RoomId,
                    SurfaceType = "Ceiling",
                    Label = "Bedroom 1 Ceiling",
                    AreaM2 = 11.60m,
                    SubstrateType = "Plasterboard",
                    Notes = "Light skim needed"
                },
                new Surface
                {
                    RoomId = rooms[3].RoomId,
                    SurfaceType = "Wall",
                    Label = "Bedroom 2 West Wall",
                    AreaM2 = 8.90m,
                    SubstrateType = "Plasterboard",
                    Notes = "Surface sanding required"
                },
                new Surface
                {
                    RoomId = rooms[4].RoomId,
                    SurfaceType = "Ceiling",
                    Label = "Kitchen Ceiling",
                    AreaM2 = 14.80m,
                    SubstrateType = "Plasterboard",
                    Notes = "Reskim full ceiling"
                },
                new Surface
                {
                    RoomId = rooms[4].RoomId,
                    SurfaceType = "Wall",
                    Label = "Kitchen South Wall",
                    AreaM2 = 7.40m,
                    SubstrateType = "Plasterboard",
                    Notes = "Cupboard side wall"
                },
                new Surface
                {
                    RoomId = rooms[5].RoomId,
                    SurfaceType = "Wall",
                    Label = "Dining Main Wall",
                    AreaM2 = 13.20m,
                    SubstrateType = "Old Plaster",
                    Notes = "Small defects visible"
                },
                new Surface
                {
                    RoomId = rooms[6].RoomId,
                    SurfaceType = "Wall",
                    Label = "Reception Front Wall",
                    AreaM2 = 16.10m,
                    SubstrateType = "Concrete",
                    Notes = "Commercial prep"
                },
                new Surface
                {
                    RoomId = rooms[7].RoomId,
                    SurfaceType = "Wall",
                    Label = "Meeting Room East Wall",
                    AreaM2 = 9.75m,
                    SubstrateType = "Plasterboard",
                    Notes = "Requires patching"
                },
                new Surface
                {
                    RoomId = rooms[8].RoomId,
                    SurfaceType = "Ceiling",
                    Label = "Bathroom Ceiling",
                    AreaM2 = 6.30m,
                    SubstrateType = "Fibre Cement",
                    Notes = "Moisture resistant finish needed"
                },
                new Surface
                {
                    RoomId = rooms[8].RoomId,
                    SurfaceType = "Wall",
                    Label = "Bathroom Shower Wall",
                    AreaM2 = 5.50m,
                    SubstrateType = "Fibre Cement",
                    Notes = "Patch around fittings"
                },
                new Surface
                {
                    RoomId = rooms[9].RoomId,
                    SurfaceType = "Wall",
                    Label = "Laundry Back Wall",
                    AreaM2 = 6.80m,
                    SubstrateType = "Concrete",
                    Notes = "Utility area surface"
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
      },
      new EventType
      {
          Name = "Second Coat",
          Categoery = "Application",
          IsActive = true,
          BusinessId = businesses[0].BusinessId
      },
      new EventType
      {
          Name = "Sanding",
          Categoery = "Finishing",
          IsActive = true,
          BusinessId = businesses[1].BusinessId
      },
      new EventType
      {
          Name = "Final Check",
          Categoery = "Finishing",
          IsActive = true,
          BusinessId = businesses[1].BusinessId
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
        UserId = users[2].UserId,
        EventTypeId = eventTypes[2].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-03T08:00:00"),
        EndedAt = DateTime.Parse("2026-04-03T17:00:00"),
        Notes = "Applied first coat of plaster to north wall."
    },
    new WorkEvent
    {
        SurfaceId = surfaces[1].SurfaceId,
        UserId = users[2].UserId,
        EventTypeId = eventTypes[2].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-03T09:15:00"),
        EndedAt = DateTime.Parse("2026-04-03T15:30:00"),
        Notes = "First coat applied to lounge ceiling."
    },
    new WorkEvent
    {
        SurfaceId = surfaces[4].SurfaceId,
        UserId = users[1].UserId,
        EventTypeId = eventTypes[1].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-06T08:30:00"),
        EndedAt = DateTime.Parse("2026-04-06T11:45:00"),
        Notes = "Prepared bedroom ceiling for skim coat."
    },
    new WorkEvent
    {
        SurfaceId = surfaces[6].SurfaceId,
        UserId = users[2].UserId,
        EventTypeId = eventTypes[3].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-11T08:00:00"),
        EndedAt = DateTime.Parse("2026-04-11T14:30:00"),
        Notes = "Second coat applied to kitchen ceiling."
    },
    new WorkEvent
    {
        SurfaceId = surfaces[8].SurfaceId,
        UserId = users[2].UserId,
        EventTypeId = eventTypes[4].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-12T10:00:00"),
        EndedAt = DateTime.Parse("2026-04-12T13:00:00"),
        Notes = "Sanded dining wall to level finish."
    },
    new WorkEvent
    {
        SurfaceId = surfaces[9].SurfaceId,
        UserId = users[4].UserId,
        EventTypeId = eventTypes[0].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-15T08:00:00"),
        EndedAt = DateTime.Parse("2026-04-15T09:20:00"),
        Notes = "Inspection of reception front wall."
    },
    new WorkEvent
    {
        SurfaceId = surfaces[10].SurfaceId,
        UserId = users[4].UserId,
        EventTypeId = eventTypes[1].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-16T09:00:00"),
        EndedAt = DateTime.Parse("2026-04-16T12:15:00"),
        Notes = "Prepared meeting room wall for patch repair."
    },
    new WorkEvent
    {
        SurfaceId = surfaces[12].SurfaceId,
        UserId = users[3].UserId,
        EventTypeId = eventTypes[5].EventTypeId,
        StartedAt = DateTime.Parse("2026-04-20T14:00:00"),
        EndedAt = DateTime.Parse("2026-04-20T15:00:00"),
        Notes = "Final check of bathroom shower wall before finish sign-off."
    }
};

            foreach (var workEvent in workEvents)
            {
                context.WorkEvents.Add(workEvent);
            }
            context.SaveChanges();




            var materials = new Material[]
            {

                new Material
                {

                    BusinessId = businesses[0].BusinessId,
                    Brand = "PlasterPro",
                    ProductName = "All-in-One Plaster",
                    MaterialType = "Plaster",
                    Notes = "Used for all plastering work on the north wall."
                },
                new Material
                {
                    BusinessId = businesses[0].BusinessId,
                    Brand = "SmoothFinish",
                    ProductName = "Premium Sanding Sealer",
                    MaterialType = "Sealer",
                    Notes = "Applied before plastering to ensure a smooth finish."
                },
                new Material
                {
                    BusinessId = businesses[0].BusinessId,
                    Brand = "QuickDry",
                    ProductName = "Fast-Drying Primer",
                    MaterialType = "Primer",
                    Notes = "Used to prime the surface before plastering."
                },
                new Material
                {
                    BusinessId = businesses[1].BusinessId,
                    Brand = "WallMaster",
                    ProductName = "Fine Finish Compound",
                    MaterialType = "Plaster",
                    Notes = "Lightweight finishing coat for office walls."
                },
                new Material
                {
                    BusinessId = businesses[1].BusinessId,
                    Brand = "DustLess",
                    ProductName = "Low Dust Sanding Coat",
                    MaterialType = "Compound",
                    Notes = "Used before sanding stage."
                }

            };

            foreach (var material in materials)
            {
                context.Materials.Add(material);

            }
            context.SaveChanges();



            var defectTypes = new DefectType[]
            {
                new DefectType
                {
                    Name = "Crack",
                    Notes = "A visible crack in the surface.",
                    BusinessId = businesses[0].BusinessId
                },
                new DefectType
                {
                    Name = "Bubble",
                    Notes = "A raised area indicating a bubble in the plaster.",
                    BusinessId = businesses[0].BusinessId
                },
                new DefectType
                {
                    Name = "Uneven Surface",
                    Notes = "An area where the surface is not smooth.",
                    BusinessId = businesses[0].BusinessId
                },
                new DefectType
                {
                    Name = "Pinholes",
                    Notes = "Small visible holes after drying.",
                    BusinessId = businesses[1].BusinessId
                },
                new DefectType
                {
                    Name = "Delamination",
                    Notes = "Loss of adhesion between layers.",
                    BusinessId = businesses[1].BusinessId
                }
            };
            foreach (var defectType in defectTypes)
            {
                context.DefectTypes.Add(defectType);
            }
            context.SaveChanges();







            var eventcontexts = new EventContext[] {

                new EventContext
                {

                    WorkEventId = workEvents[0].WorkEventId,
                    MaterialId = materials[0].MaterialId,

                    ThicknessMm = 5.0m,
                    HumidityPct = 60.0m,
                    TemperatureC = 22.0m,
                    VentilationRating = 3,
                    TimeSincePrevEventHours = 24.0m,
                    MixRatio = "1:1:1",
                    Notes = "Standard mix ratio for plaster application."
                },
                new EventContext
                {
                    WorkEventId= workEvents[1].WorkEventId,
                    MaterialId = materials[1].MaterialId,
                    ThicknessMm = 5.0m,
                    HumidityPct = 50.0m,
                    TemperatureC = 22.0m,
                    VentilationRating = 4,
                    TimeSincePrevEventHours = 12.0m,
                    MixRatio = "N/A",
                    Notes = "Sanding sealer applied before plastering."
                },
                new EventContext {
                    WorkEventId = workEvents[2].WorkEventId,
                    MaterialId= materials[2].MaterialId,
                    ThicknessMm = 4.0m,
                    HumidityPct = 55.0m,
                    TemperatureC = 22.0m,
                    VentilationRating = 6,
                    TimeSincePrevEventHours = 18.0m,
                    MixRatio = "N/A",
                    Notes = "Primer applied to ensure good adhesion of plaster."

                    },
                new EventContext
                {
                    WorkEventId = workEvents[3].WorkEventId,
                    MaterialId = materials[0].MaterialId,
                    ThicknessMm = 3.5m,
                    HumidityPct = 58.0m,
                    TemperatureC = 21.0m,
                    VentilationRating = 5,
                    TimeSincePrevEventHours = 10.0m,
                    MixRatio = "1:1",
                    Notes = "Ceiling first coat mix."
                },
                new EventContext
                {
                    WorkEventId = workEvents[4].WorkEventId,
                    MaterialId = materials[1].MaterialId,
                    ThicknessMm = 2.5m,
                    HumidityPct = 49.0m,
                    TemperatureC = 20.0m,
                    VentilationRating = 4,
                    TimeSincePrevEventHours = 14.0m,
                    MixRatio = "N/A",
                    Notes = "Prep stage before skim."
                },
                new EventContext
                {
                    WorkEventId = workEvents[5].WorkEventId,
                    MaterialId = materials[3].MaterialId,
                    ThicknessMm = 2.8m,
                    HumidityPct = 57.0m,
                    TemperatureC = 23.0m,
                    VentilationRating = 6,
                    TimeSincePrevEventHours = 22.0m,
                    MixRatio = "1:0.8",
                    Notes = "Second coat on kitchen ceiling."
                },
                new EventContext
                {
                    WorkEventId = workEvents[6].WorkEventId,
                    MaterialId = materials[4].MaterialId,
                    ThicknessMm = 1.2m,
                    HumidityPct = 54.0m,
                    TemperatureC = 21.0m,
                    VentilationRating = 7,
                    TimeSincePrevEventHours = 16.0m,
                    MixRatio = "N/A",
                    Notes = "Sanding stage context."
                },
                new EventContext
                {
                    WorkEventId = workEvents[7].WorkEventId,
                    MaterialId = materials[3].MaterialId,
                    ThicknessMm = 0.0m,
                    HumidityPct = 52.0m,
                    TemperatureC = 22.0m,
                    VentilationRating = 5,
                    TimeSincePrevEventHours = 30.0m,
                    MixRatio = "N/A",
                    Notes = "Inspection only."
                },
                new EventContext
                {
                    WorkEventId = workEvents[8].WorkEventId,
                    MaterialId = materials[4].MaterialId,
                    ThicknessMm = 1.8m,
                    HumidityPct = 53.0m,
                    TemperatureC = 20.0m,
                    VentilationRating = 5,
                    TimeSincePrevEventHours = 11.0m,
                    MixRatio = "N/A",
                    Notes = "Patch prep for meeting room wall."
                },
                new EventContext
                {
                    WorkEventId = workEvents[9].WorkEventId,
                    MaterialId = materials[3].MaterialId,
                    ThicknessMm = 0.5m,
                    HumidityPct = 61.0m,
                    TemperatureC = 24.0m,
                    VentilationRating = 6,
                    TimeSincePrevEventHours = 20.0m,
                    MixRatio = "N/A",
                    Notes = "Final check conditions."
                }
                };
            foreach (var eventcontext in eventcontexts)
            {
                context.EventContexts.Add(eventcontext);
            }
            context.SaveChanges();



            var eventoutcomes = new EventOutcome[]
            {
                new EventOutcome {
                    WorkEventId = workEvents[0].WorkEventId,
                    OutcomeStatus = "Success",
                    DryTimeHoursActual = 6.0m,
                    ReworkRequired = false,
                    QualityRating = 5,
                    Notes = "First coat dried successfully with excellent finish."

            },
                new EventOutcome {
                    WorkEventId= workEvents[1].WorkEventId,
                    OutcomeStatus = "Minor Issues",
                    DryTimeHoursActual = 8.0m,
                    ReworkRequired = true,
                    QualityRating= 2,
                    Notes = "Some minor cracking observed, rework required to fix imperfections."
                },
                new EventOutcome {
                    WorkEventId=workEvents[2].WorkEventId,
                    OutcomeStatus = "Success",
                    DryTimeHoursActual = 5.0m,
                    ReworkRequired = false,
                    QualityRating = 4,
                    Notes = "Primer dried well, surface ready for plastering."
                },
                new EventOutcome
                {
                    WorkEventId = workEvents[3].WorkEventId,
                    OutcomeStatus = "Success",
                    DryTimeHoursActual = 6.5m,
                    ReworkRequired = false,
                    QualityRating = 4,
                    Notes = "Ceiling coat levelled well."
                },
                new EventOutcome
                {
                    WorkEventId = workEvents[4].WorkEventId,
                    OutcomeStatus = "Success",
                    DryTimeHoursActual = 3.0m,
                    ReworkRequired = false,
                    QualityRating = 4,
                    Notes = "Preparation stage completed cleanly."
                },
                new EventOutcome
                {
                    WorkEventId = workEvents[5].WorkEventId,
                    OutcomeStatus = "Success",
                    DryTimeHoursActual = 7.0m,
                    ReworkRequired = false,
                    QualityRating = 5,
                    Notes = "Second coat finish was smooth."
                },
                new EventOutcome
                {
                    WorkEventId = workEvents[6].WorkEventId,
                    OutcomeStatus = "Minor Issues",
                    DryTimeHoursActual = 2.0m,
                    ReworkRequired = true,
                    QualityRating = 3,
                    Notes = "Sanding revealed a shallow low spot."
                },
                new EventOutcome
                {
                    WorkEventId = workEvents[7].WorkEventId,
                    OutcomeStatus = "Success",
                    DryTimeHoursActual = 0.0m,
                    ReworkRequired = false,
                    QualityRating = 4,
                    Notes = "Inspection completed with no major issues."
                },
                new EventOutcome
                {
                    WorkEventId = workEvents[8].WorkEventId,
                    OutcomeStatus = "Success",
                    DryTimeHoursActual = 3.8m,
                    ReworkRequired = false,
                    QualityRating = 4,
                    Notes = "Patch prep completed and ready for coat."
                },
                new EventOutcome
                {
                    WorkEventId = workEvents[9].WorkEventId,
                    OutcomeStatus = "Success",
                    DryTimeHoursActual = 0.0m,
                    ReworkRequired = false,
                    QualityRating = 5,
                    Notes = "Final check signed off."
                }
        };
            foreach (var eventout in eventoutcomes)
            {
                context.EventOutcomes.Add(eventout);
            }
            context.SaveChanges();





            var evidencephotos = new EvidencePhoto[]
 {
                new EvidencePhoto
                {
                    WorkEventId = workEvents[0].WorkEventId,
                    FileUrl = "/Images/inspection1.jpg",
                    Caption = "Initial inspection of north wall surface.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[1].WorkEventId,
                    FileUrl = "/Images/preparation1.jpg",
                    Caption = "Surface preparation including sanding and cleaning.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[2].WorkEventId,
                    FileUrl = "/Images/application1.jpg",
                    Caption = "Applied first coat of plaster to north wall.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[3].WorkEventId,
                    FileUrl = "/Images/loungeceiling1.jpg",
                    Caption = "First coat on lounge ceiling.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[4].WorkEventId,
                    FileUrl = "/Images/bedceilingprep1.jpg",
                    Caption = "Preparation stage for bedroom ceiling.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[5].WorkEventId,
                    FileUrl = "/Images/kitchenceiling2.jpg",
                    Caption = "Second coat on kitchen ceiling.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[6].WorkEventId,
                    FileUrl = "/Images/diningsand1.jpg",
                    Caption = "Sanding stage on dining wall.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[7].WorkEventId,
                    FileUrl = "/Images/receptioninspect1.jpg",
                    Caption = "Reception wall inspection.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[8].WorkEventId,
                    FileUrl = "/Images/meetingprep1.jpg",
                    Caption = "Meeting room wall preparation.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[9].WorkEventId,
                    FileUrl = "/Images/bathroomfinal1.jpg",
                    Caption = "Final check of bathroom shower wall.",
                    TakenAt = DateTime.Now,
                }
 };

            foreach (var photo in evidencephotos)
            {
                context.EvidencePhotos.Add(photo);
            }
            context.SaveChanges();







            var defectreports = new DefectReport[]
            {
                new DefectReport
                {
                    SurfaceId = surfaces[0].SurfaceId,
                    DefectTypeId = defectTypes[0].DefectTypeId,
                   ReportedAt = DateTime.Now,
                    Severity = 3,
                     Description = "Crack observed in the plaster after drying.",
                    SuspectedCauseEventId = 0,
                    FixEventId = 0,
                    Status = "Open"
                },
                new DefectReport
                {
                    SurfaceId = surfaces[0].SurfaceId,
                    DefectTypeId = defectTypes[1].DefectTypeId,
                    ReportedAt = DateTime.Now,
                    Severity = 2,
                    Description = "Bubble observed in the plaster surface.",
                    SuspectedCauseEventId = 0,
                    FixEventId = 0,
                    Status = "Open"
                },
                new DefectReport
                {
                    SurfaceId = surfaces[0].SurfaceId,
                    DefectTypeId = defectTypes[2].DefectTypeId,
                    ReportedAt = DateTime.Now,
                    Severity = 2,
                    Description = "Uneven surface observed after first coat application.",
                    SuspectedCauseEventId= 0,
                    FixEventId= 0,
                    Status = "Open"
                },
                new DefectReport
                {
                    SurfaceId = surfaces[6].SurfaceId,
                    DefectTypeId = defectTypes[2].DefectTypeId,
                    ReportedAt = DateTime.Now,
                    Severity = 1,
                    Description = "Minor unevenness near the kitchen light fitting.",
                    SuspectedCauseEventId = 0,
                    FixEventId = 0,
                    Status = "Monitoring"
                },
                new DefectReport
                {
                    SurfaceId = surfaces[8].SurfaceId,
                    DefectTypeId = defectTypes[3].DefectTypeId,
                    ReportedAt = DateTime.Now,
                    Severity = 2,
                    Description = "Small pinholes visible on dining wall after sanding.",
                    SuspectedCauseEventId = 0,
                    FixEventId = 0,
                    Status = "Open"
                },
                new DefectReport
                {
                    SurfaceId = surfaces[9].SurfaceId,
                    DefectTypeId = defectTypes[4].DefectTypeId,
                    ReportedAt = DateTime.Now,
                    Severity = 4,
                    Description = "Loss of adhesion found on reception front wall.",
                    SuspectedCauseEventId = 0,
                    FixEventId = 0,
                    Status = "Open"
                },
                new DefectReport
                {
                    SurfaceId = surfaces[10].SurfaceId,
                    DefectTypeId = defectTypes[0].DefectTypeId,
                    ReportedAt = DateTime.Now,
                    Severity = 2,
                    Description = "Hairline crack around patched area.",
                    SuspectedCauseEventId = 0,
                    FixEventId = 0,
                    Status = "Open"
                },
                new DefectReport
                {
                    SurfaceId = surfaces[12].SurfaceId,
                    DefectTypeId = defectTypes[1].DefectTypeId,
                    ReportedAt = DateTime.Now,
                    Severity = 1,
                    Description = "Minor surface bubbling near shower fitting.",
                    SuspectedCauseEventId = 0,
                    FixEventId = 0,
                    Status = "Monitoring"
                }




            };

            foreach (var defectReport in defectreports)
            {
                context.DefectReports.Add(defectReport);
            }
            context.SaveChanges();





            var patterns = new Pattern[]
            {
                new Pattern
                {
                    Title = "Crack Pattern",
                    Description = "Common crack patterns observed in plaster surfaces.",
                    Confidence = 0.70m,
                    CreatedAt = DateTime.Now,
                    BusinessId = businesses[0].BusinessId
                },
                new Pattern
                {
                    Title = "Bubble Pattern",
                    Description = "Typical bubble formations in plaster surfaces.",
                    Confidence = 0.81m,
                    CreatedAt = DateTime.Now,
                    BusinessId = businesses[0].BusinessId
                },
                new Pattern
                {
                    Title = "Uneven Surface Pattern",
                    Description = "Patterns of uneven surfaces observed after plaster application.",
                    Confidence = 0.85m,
                    CreatedAt = DateTime.Now,
                    BusinessId = businesses[0].BusinessId
                },
                new Pattern
                {
                    Title = "Pinhole Pattern",
                    Description = "Recurring pinhole defects after sanding and finishing stages.",
                    Confidence = 0.76m,
                    CreatedAt = DateTime.Now,
                    BusinessId = businesses[1].BusinessId
                },
                new Pattern
                {
                    Title = "Delamination Pattern",
                    Description = "Adhesion-related defects linked to unsuitable substrate conditions.",
                    Confidence = 0.88m,
                    CreatedAt = DateTime.Now,
                    BusinessId = businesses[1].BusinessId
                }
            };



            foreach (var pattern in patterns)
            {
                context.Patterns.Add(pattern);
            }
            context.SaveChanges();












            var patternrules = new PatternRule[]
            {
                new PatternRule
                {
                    PatternId = patterns[0].PatternId,
                    FieldName = "HumidityPct",
                    Operator = ">",
                    Value1 = "65",
                    Value2 = "N/A"

                },
                new PatternRule
                {
                    PatternId = patterns[1].PatternId,
                    FieldName = "VentilationRating",
                    Operator= ">",
                    Value1 = "4",
                    Value2 = "N/A"

                },
                new PatternRule
                {
                    PatternId = patterns[2].PatternId,
                    FieldName = "TimeSincePrevEventHours",
                    Operator = ">",
                    Value1 = "20",
                    Value2 = "N/A"

                },
                new PatternRule
                {
                    PatternId = patterns[3].PatternId,
                    FieldName = "DryTimeHoursActual",
                    Operator = ">",
                    Value1 = "6",
                    Value2 = "N/A"

                },
                new PatternRule
                {
                    PatternId = patterns[4].PatternId,
                    FieldName = "SubstrateType",
                    Operator = "=",
                    Value1 = "Concrete",
                    Value2 = "N/A"

                }
            };


            foreach (var patternRule in patternrules)
            {
                context.PatternRules.Add(patternRule);
            }
            context.SaveChanges();


            var patternoutcomes = new PatternOutcome[]
            {

                new PatternOutcome {
                    PatternId = patterns[0].PatternId,
                    OutcomeMetric = "Crack Severity",
                    Probability = 0.70m,
                    Notes = "Higher humidity levels are associated with increased crack severity."

            },

                new PatternOutcome {
                PatternId= patterns[1].PatternId,
                OutcomeMetric = "Bubble Size",
                Probability = 0.81m,
                Notes = "Poor ventilation is linked to larger bubble formations in plaster surfaces."

                },

               new PatternOutcome
               {
                   PatternId= patterns[2].PatternId,
                   OutcomeMetric = "Surface Unevenness",
                   Probability = 0.85m,
                   Notes = "Longer time between events is correlated with increased surface unevenness after plaster application."
               },
               new PatternOutcome
               {
                   PatternId = patterns[3].PatternId,
                   OutcomeMetric = "Pinhole Frequency",
                   Probability = 0.76m,
                   Notes = "Longer drying times are linked to more visible pinholes after sanding."
               },
               new PatternOutcome
               {
                   PatternId = patterns[4].PatternId,
                   OutcomeMetric = "Adhesion Failure Risk",
                   Probability = 0.88m,
                   Notes = "Concrete substrates with poor prep show a higher chance of delamination."
               }
            };

            foreach (var patternOutcome in patternoutcomes)
            {
                context.PatternOutcomes.Add(patternOutcome);
            }
            context.SaveChanges();












        }

    }
}