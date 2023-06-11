using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasteryShop.Migrations
{
    /// <inheritdoc />
    public partial class editPieClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl",
                table: "Pies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl",
                table: "Pies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
