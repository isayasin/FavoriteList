using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavoriteList.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "Chk_Fav_Star",
                table: "favLists",
                sql: "[Star]<=5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Chk_Fav_Star",
                table: "favLists");
        }
    }
}
