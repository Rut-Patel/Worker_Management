using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Worker_Management.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supervisiors",
                columns: table => new
                {
                    supervisiorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisiors", x => x.supervisiorID);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    workerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    hired_date = table.Column<DateTime>(nullable: false),
                    SupervisiorFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.workerID);
                    table.ForeignKey(
                        name: "FK_Workers_Supervisiors_SupervisiorFK",
                        column: x => x.SupervisiorFK,
                        principalTable: "Supervisiors",
                        principalColumn: "supervisiorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_SupervisiorFK",
                table: "Workers",
                column: "SupervisiorFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Supervisiors");
        }
    }
}
