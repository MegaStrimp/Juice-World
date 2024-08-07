using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Juice_World.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Juice",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Juice",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Juice");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Juice");
        }
    }
}
