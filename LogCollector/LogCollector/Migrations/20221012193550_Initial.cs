using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogCollector.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LogLevel = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LogMessage = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", maxLength: 16384, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
