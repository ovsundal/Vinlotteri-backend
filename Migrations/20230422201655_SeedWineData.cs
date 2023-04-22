using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinlotteri_backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedWineData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Wines",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Chateau Ste. Michelle Columbia Valley Syrah 2018", 190m},
                    { 2, "Penfolds Bin 389 Cabernet Shiraz 2017", 210m },
                    { 3, "Opus One Napa Valley Red Wine 2017", 240m },
                    { 4, "Château Pape Clément Pessac-Léognan 2016", 220m },
                    { 5, "Château Montrose St.-Estèphe 2017", 230m },
                    { 6, "Petaluma Adelaide Hills Chardonnay 2018", 180m },
                    { 7, "Marchesi Antinori Solaia Toscana 2016", 200m },
                    { 8, "Caymus Vineyards Cabernet Sauvignon Napa Valley 2018", 250m },
                    { 9, "Castello di Ama Chianti Classico 2017", 160m },
                    { 10, "Torbreck The Struie Barossa Valley Shiraz 2017", 170m },
                    { 11, "Le Macchiole Paleo Bolgheri 2018", 190m },
                    { 12, "Louis Jadot Chapelle-Chambertin Grand Cru 2015", 210m },
                    { 13, "Tignanello Antinori Toscana 2017", 220m },
                    { 14, "Harlan Estate Napa Valley Red Wine 2016", 240m },
                    { 15, "Gaja Sorì San Lorenzo Langhe 2015", 230m },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Wines",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
        }
    }
}
