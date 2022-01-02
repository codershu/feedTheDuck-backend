using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace feedTheDuck.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuckFeedRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    DuckType = table.Column<string>(nullable: true),
                    DuckAmount = table.Column<long>(nullable: false),
                    Food = table.Column<string>(nullable: true),
                    FoodMetric = table.Column<string>(nullable: true),
                    FoodAmount = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuckFeedRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccess",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccess", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuckFeedRecords");

            migrationBuilder.DropTable(
                name: "UserAccess");
        }
    }
}
