using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Animals",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Name", "Sex", "Species", "Weight" },
                values: new object[,]
                {
                    { 1, 16, "Taki", "Male", "Dog", 53 },
                    { 2, 43, "Ginger", "Female", "Dog", 70 },
                    { 3, 36, "Rollie", "Male", "Rabbit", 6 },
                    { 4, 26, "Gunther", "Male", "Dog", 74 },
                    { 5, 60, "Raina", "Female", "Cat", 7 },
                    { 6, 9, "Butterscotch", "Male", "Cat", 11 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Animals");
        }
    }
}
