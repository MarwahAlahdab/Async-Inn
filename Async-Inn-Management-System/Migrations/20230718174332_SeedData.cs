using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Async_Inn_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetFriendly",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Amenities");

            migrationBuilder.RenameColumn(
                name: "Layout",
                table: "Rooms",
                newName: "NickName");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "Amenities",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "PetFriendly",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Rooms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Amenity 1" },
                    { 2, "Amenity 2" },
                    { 3, "Amenity 3" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "City", "Country", "Name", "Phone", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "City 1", "Country 1", "Hotel 1", "Phone 1", "State 1", "Address 1" },
                    { 2, "City 2", "Country 2", "Hotel 2", "Phone 2", "State 2", "Address 2" },
                    { 3, "City 3", "Country 3", "Hotel 3", "Phone 3", "State 3", "Address 3" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "Name", "NickName", "PetFriendly", "Price" },
                values: new object[,]
                {
                    { 1, "Room 1", "Nickname 1", true, 100.0 },
                    { 2, "Room 2", "Nickname 2", false, 120.0 },
                    { 3, "Room 3", "Nickname 3", true, 150.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PetFriendly",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "Rooms",
                newName: "Layout");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Amenities",
                newName: "NickName");

            migrationBuilder.AddColumn<bool>(
                name: "PetFriendly",
                table: "Amenities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Amenities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
