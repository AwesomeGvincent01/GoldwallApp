using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldwallApp.Migrations
{
    /// <inheritdoc />
    public partial class AllModelsDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SuspectedCauseEventId = table.Column<int>(type: "int", nullable: false),
                    FixEventId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectReport", x => x.DefectReportId);
                });

            migrationBuilder.CreateTable(
                name: "DefectType",
                columns: table => new
                {
                    DefectTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectType", x => x.DefectTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EventContext",
                columns: table => new
                {
                    WorkEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "EventOutcome",
                columns: table => new
                {
                    WorkEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutcomeStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DryTimeHoursActual = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    ReworkRequired = table.Column<bool>(type: "bit", nullable: false),
                    QualityRating = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOutcome", x => x.WorkEventId);
                });

            migrationBuilder.CreateTable(
                name: "EvidencePhoto",
                columns: table => new
                {
                    EvidencePhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkEventId = table.Column<int>(type: "int", nullable: false),
                    DefectReportId = table.Column<int>(type: "int", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TakenAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidencePhoto", x => x.EvidencePhotoId);
                });

            migrationBuilder.CreateTable(
                name: "Pattern",
                columns: table => new
                {
                    PatternId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Confidence = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pattern", x => x.PatternId);
                });

            migrationBuilder.CreateTable(
                name: "PatternOutcome",
                columns: table => new
                {
                    PatternOutcomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternId = table.Column<int>(type: "int", nullable: false),
                    OutcomeMetric = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Probability = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternOutcome", x => x.PatternOutcomeId);
                });

            migrationBuilder.CreateTable(
                name: "PatternRule",
                columns: table => new
                {
                    PatternRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Value1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatternRule", x => x.PatternRuleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefectReport");

            migrationBuilder.DropTable(
                name: "DefectType");

            migrationBuilder.DropTable(
                name: "EventContext");

            migrationBuilder.DropTable(
                name: "EventOutcome");

            migrationBuilder.DropTable(
                name: "EvidencePhoto");

            migrationBuilder.DropTable(
                name: "Pattern");

            migrationBuilder.DropTable(
                name: "PatternOutcome");

            migrationBuilder.DropTable(
                name: "PatternRule");
        }
    }
}
