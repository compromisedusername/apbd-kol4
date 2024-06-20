using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolosTest2.Migrations
{
    /// <inheritdoc />
    public partial class FixEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "character_titles");

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharactedId", "TitleId" },
                keyValues: new object[] { 1, 1 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 22, 20, 41, 14, 158, DateTimeKind.Local).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharactedId", "TitleId" },
                keyValues: new object[] { 2, 2 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 22, 20, 41, 14, 162, DateTimeKind.Local).AddTicks(3346));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "character_titles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharactedId", "TitleId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "AcquiredAt", "Title" },
                values: new object[] { new DateTime(2024, 6, 22, 20, 6, 46, 641, DateTimeKind.Local).AddTicks(9769), "Tytul1" });

            migrationBuilder.UpdateData(
                table: "character_titles",
                keyColumns: new[] { "CharactedId", "TitleId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "AcquiredAt", "Title" },
                values: new object[] { new DateTime(2024, 6, 22, 20, 6, 46, 645, DateTimeKind.Local).AddTicks(6067), "Tytul2" });
        }
    }
}
