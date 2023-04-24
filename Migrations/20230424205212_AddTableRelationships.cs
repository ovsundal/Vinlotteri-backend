using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinlotteri_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTableRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Lotteries_LotteryId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "LotteryId",
                table: "Wines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "LotteryId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wines_LotteryId",
                table: "Wines",
                column: "LotteryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Lotteries_LotteryId",
                table: "Tickets",
                column: "LotteryId",
                principalTable: "Lotteries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Lotteries_LotteryId",
                table: "Wines",
                column: "LotteryId",
                principalTable: "Lotteries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Lotteries_LotteryId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Lotteries_LotteryId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_LotteryId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "LotteryId",
                table: "Wines");

            migrationBuilder.AlterColumn<int>(
                name: "LotteryId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Lotteries_LotteryId",
                table: "Tickets",
                column: "LotteryId",
                principalTable: "Lotteries",
                principalColumn: "Id");
        }
    }
}
