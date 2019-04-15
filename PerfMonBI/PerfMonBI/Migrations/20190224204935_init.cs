using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElGuerre.PowerBI.PerformanceCounters.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AverageCounters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineName = table.Column<string>(nullable: true),
                    ProcessorTime = table.Column<double>(nullable: false),
                    AvailableMemoryGB = table.Column<double>(nullable: false),
                    AvailableDiskSpaceGB = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AverageCounters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineName = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    ProcessorTime = table.Column<double>(nullable: false),
                    AvailableMemoryGB = table.Column<double>(nullable: false),
                    AvailableDiskSpaceGB = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AverageCounters");

            migrationBuilder.DropTable(
                name: "Counters");
        }
    }
}
