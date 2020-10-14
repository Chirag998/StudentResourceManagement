using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentResourceManagement.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    RID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.RID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    SID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.SID);
                });

            migrationBuilder.CreateTable(
                name: "StudentResources",
                columns: table => new
                {
                    SID = table.Column<int>(nullable: false),
                    RID = table.Column<int>(nullable: false),
                    AssignedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentResources", x => new { x.SID, x.RID });
                    table.ForeignKey(
                        name: "FK_StudentResources_Resources_RID",
                        column: x => x.RID,
                        principalTable: "Resources",
                        principalColumn: "RID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentResources_Students_SID",
                        column: x => x.SID,
                        principalTable: "Students",
                        principalColumn: "SID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentResources_RID",
                table: "StudentResources",
                column: "RID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentResources");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
