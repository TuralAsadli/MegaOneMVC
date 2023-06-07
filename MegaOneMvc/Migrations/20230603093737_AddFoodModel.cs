using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaOneMvc.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DealDescription",
                table: "Deals",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Deals",
                newName: "DealDescription");
        }
    }
}
