using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardCode.Data.Migrations
{
    public partial class JekeSostav1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JekeSostav",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doljnost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InviteMonthYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sinyptilik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eskertpe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JekeSostav", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JekeSostav");
        }
    }
}
