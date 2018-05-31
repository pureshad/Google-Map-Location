using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyLocation002.Migrations
{
    public partial class ChangesColumnType_FromDoubleToFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Coordinates",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Coordinates",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
