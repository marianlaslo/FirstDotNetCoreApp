using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstDotNetCoreApp.Migrations
{
    public partial class AddedAbstractionOverModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Files",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Files",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreateDate",
                value: new DateTime(2018, 12, 6, 16, 10, 12, 651, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Files");
        }
    }
}
