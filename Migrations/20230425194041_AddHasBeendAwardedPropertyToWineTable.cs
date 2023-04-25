using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinlotteri_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddHasBeendAwardedPropertyToWineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBeenAwarded",
                table: "Wines",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBeenAwarded",
                table: "Wines");
        }
    }
}
