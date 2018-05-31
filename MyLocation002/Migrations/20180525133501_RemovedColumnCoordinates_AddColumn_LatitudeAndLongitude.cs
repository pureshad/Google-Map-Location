using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyLocation002.Migrations
{
    public partial class RemovedColumnCoordinates_AddColumn_LatitudeAndLongitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Coordinates",
                table: "Locations",
                newName: "Longitude");

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Locations",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Locations",
                newName: "Coordinates");
        }
    }
}
