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
                    FileUrl = "https://example.com/photos/inspection1.jpg",
                    Caption = "Initial inspection of north wall surface.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[1].WorkEventId,
                    FileUrl = "https://example.com/photos/preparation1.jpg",
                    Caption = "Surface preparation including sanding and cleaning.",
                    TakenAt = DateTime.Now,
                },
                new EvidencePhoto
                {
                    WorkEventId = workEvents[2].WorkEventId,
                    FileUrl = "https://example.com/photos/application1.jpg",
                    Caption = "Applied first coat of plaster to north wall.",
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