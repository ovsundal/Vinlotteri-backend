using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinlotteri_backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWinePropertyType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBeenAwarded",
                table: "Wines");

            migrationBuilder.AddColumn<string>(
                name: "WonBy",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WonBy",
                table: "Wines");

            migrationBuilder.AddColumn<bool>(
                name: "HasBeenAwarded",
                table: "Wines",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
