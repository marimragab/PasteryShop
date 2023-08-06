using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasteryShop.Migrations
{
    /// <inheritdoc />
    public partial class editDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllergyInformation",
                table: "Pies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl",
                table: "Pies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllergyInformation",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl",
                table: "Pies");
        }
    }
}
