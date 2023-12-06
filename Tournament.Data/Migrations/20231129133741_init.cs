using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournamnetmainmodel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournamnetmainmodel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gamemodel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    TournamnetmainmodelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamemodel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gamemodel_Tournamnetmainmodel_TournamnetmainmodelID",
                        column: x => x.TournamnetmainmodelID,
                        principalTable: "Tournamnetmainmodel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gamemodel_TournamnetmainmodelID",
                table: "Gamemodel",
                column: "TournamnetmainmodelID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gamemodel");

            migrationBuilder.DropTable(
                name: "Tournamnetmainmodel");
        }
    }
}
