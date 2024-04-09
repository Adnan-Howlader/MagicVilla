using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaApi.Migrations
{
    /// <inheritdoc />
    public partial class adding_records : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Details", "Name", "UpdateDate", "amenity", "imageurl", "occupancy", "rate", "sqft" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 9, 14, 53, 27, 638, DateTimeKind.Local).AddTicks(9970), "Villa1 Details", "Villa1", new DateTime(2024, 4, 9, 14, 53, 27, 639, DateTimeKind.Local).AddTicks(10), "Villa1 Amenities", "", true, 100.0, 1000 },
                    { 2, new DateTime(2024, 4, 9, 14, 53, 27, 639, DateTimeKind.Local).AddTicks(40), "Villa2 Details", "Villa2", new DateTime(2024, 4, 9, 14, 53, 27, 639, DateTimeKind.Local).AddTicks(40), "Villa2 Amenities", "", true, 200.0, 2000 },
                    { 3, new DateTime(2024, 4, 9, 14, 53, 27, 639, DateTimeKind.Local).AddTicks(50), "Villa3 Details", "Villa3", new DateTime(2024, 4, 9, 14, 53, 27, 639, DateTimeKind.Local).AddTicks(60), "Villa3 Amenities", "", true, 300.0, 3000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
