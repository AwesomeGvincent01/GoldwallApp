using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldwallApp.Migrations
{
    /// <inheritdoc />
    public partial class IFormFileIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefectType",
                columns: table => new
                {
                    DefectTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectType", x => x.DefectTypeId);
                    table.ForeignKey(
                        name: "FK_DefectType_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Categoery = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.EventTypeId);
                    table.ForeignKey(
                        name: "FK_EventType_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaterialType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Material_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pattern",
                columns: table => new
                {
                    PatternId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Confidence = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pattern", x => x.PatternId);
                    table.ForeignKey(
                        name: "FK_Pattern_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StartDatePlanned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDatePlanned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Job_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatternOutcome",
                columns: table => new
                {
                    PatternOutcomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternId = table.Column<int>(type: "int", nullable: false),
                    OutcomeMetric = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Probability = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternOutcome", x => x.PatternOutcomeId);
                    table.ForeignKey(
                        name: "FK_PatternOutcome_Pattern_PatternId",
                        column: x => x.PatternId,
                        principalTable: "Pattern",
                        principalColumn: "PatternId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatternRule",
                columns: table => new
                {
                    PatternRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternRule", x => x.PatternRuleId);
                    table.ForeignKey(
                        name: "FK_PatternRule_Pattern_PatternId",
                        column: x => x.PatternId,
                        principalTable: "Pattern",
                        principalColumn: "PatternId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Surface",
                columns: table => new
                {
                    SurfaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    SurfaceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AreaM2 = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    SubstrateType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surface", x => x.SurfaceId);
                    table.ForeignKey(
                        name: "FK_Surface_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefectReport",
                columns: table => new
                {
                    DefectReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfaceId = table.Column<int>(type: "int", nullable: false),
                    DefectTypeId = table.Column<int>(type: "int", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SuspectedCauseEventId = table.Column<int>(type: "int", nullable: true),
                    FixEventId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectReport", x => x.DefectReportId);
                    table.ForeignKey(
                        name: "FK_DefectReport_DefectType_DefectTypeId",
                        column: x => x.DefectTypeId,
                        principalTable: "DefectType",
                        principalColumn: "DefectTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefectReport_Surface_SurfaceId",
                        column: x => x.SurfaceId,
                        principalTable: "Surface",
                        principalColumn: "SurfaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkEvent",
                columns: table => new
                {
                    WorkEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfaceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEvent", x => x.WorkEventId);
                    table.ForeignKey(
                        name: "FK_WorkEvent_EventType_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventType",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkEvent_Surface_SurfaceId",
                        column: x => x.SurfaceId,
                        principalTable: "Surface",
                        principalColumn: "SurfaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkEvent_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventContext",
                columns: table => new
                {
                    WorkEventId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    ThicknessMm = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    HumidityPct = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    TemperatureC = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    VentilationRating = table.Column<int>(type: "int", nullable: false),
                    TimeSincePrevEventHours = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    MixRatio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventContext", x => x.WorkEventId);
                    table.ForeignKey(
                        name: "FK_EventContext_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventContext_WorkEvent_WorkEventId",
                        column: x => x.WorkEventId,
                        principalTable: "WorkEvent",
                        principalColumn: "WorkEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventOutcome",
                columns: table => new
                {
                    WorkEventId = table.Column<int>(type: "int", nullable: false),
                    OutcomeStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DryTimeHoursActual = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    ReworkRequired = table.Column<bool>(type: "bit", nullable: false),
                    QualityRating = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOutcome", x => x.WorkEventId);
                    table.ForeignKey(
                        name: "FK_EventOutcome_WorkEvent_WorkEventId",
                        column: x => x.WorkEventId,
                        principalTable: "WorkEvent",
                        principalColumn: "WorkEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvidencePhoto",
                columns: table => new
                {
                    EvidencePhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkEventId = table.Column<int>(type: "int", nullable: false),
                    DefectReportId = table.Column<int>(type: "int", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TakenAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidencePhoto", x => x.EvidencePhotoId);
                    table.ForeignKey(
                        name: "FK_EvidencePhoto_DefectReport_DefectReportId",
                        column: x => x.DefectReportId,
                        principalTable: "DefectReport",
                        principalColumn: "DefectReportId");
                    table.ForeignKey(
                        name: "FK_EvidencePhoto_WorkEvent_WorkEventId",
                        column: x => x.WorkEventId,
                        principalTable: "WorkEvent",
                        principalColumn: "WorkEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_BusinessId",
                table: "Client",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectReport_DefectTypeId",
                table: "DefectReport",
                column: "DefectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectReport_SurfaceId",
                table: "DefectReport",
                column: "SurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectType_BusinessId",
                table: "DefectType",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_EventContext_MaterialId",
                table: "EventContext",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EventType_BusinessId",
                table: "EventType",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidencePhoto_DefectReportId",
                table: "EvidencePhoto",
                column: "DefectReportId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidencePhoto_WorkEventId",
                table: "EvidencePhoto",
                column: "WorkEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_BusinessId",
                table: "Job",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_ClientId",
                table: "Job",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_BusinessId",
                table: "Material",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Pattern_BusinessId",
                table: "Pattern",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PatternOutcome_PatternId",
                table: "PatternOutcome",
                column: "PatternId");

            migrationBuilder.CreateIndex(
                name: "IX_PatternRule_PatternId",
                table: "PatternRule",
                column: "PatternId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_JobId",
                table: "Room",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Surface_RoomId",
                table: "Surface",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_User_BusinessId",
                table: "User",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEvent_EventTypeId",
                table: "WorkEvent",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEvent_SurfaceId",
                table: "WorkEvent",
                column: "SurfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEvent_UserId",
                table: "WorkEvent",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventContext");

            migrationBuilder.DropTable(
                name: "EventOutcome");

            migrationBuilder.DropTable(
                name: "EvidencePhoto");

            migrationBuilder.DropTable(
                name: "PatternOutcome");

            migrationBuilder.DropTable(
                name: "PatternRule");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "DefectReport");

            migrationBuilder.DropTable(
                name: "WorkEvent");

            migrationBuilder.DropTable(
                name: "Pattern");

            migrationBuilder.DropTable(
                name: "DefectType");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "Surface");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Business");
        }
    }
}
