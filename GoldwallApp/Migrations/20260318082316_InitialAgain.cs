using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldwallApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullNaame",
                table: "User",
                newName: "FullName");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Job");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "User",
                newName: "FullNaame");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Client",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
