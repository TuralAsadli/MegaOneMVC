using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaOneMvc.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "Categories",
                newName: "IconName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconName",
                table: "Categories",
                newName: "ImgPath");
        }
    }
}
