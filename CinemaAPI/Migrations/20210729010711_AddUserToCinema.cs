using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaAPI.Migrations
{
    public partial class AddUserToCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Cinemas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_CreatedById",
                table: "Cinemas",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Users_CreatedById",
                table: "Cinemas",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Users_CreatedById",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_CreatedById",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Cinemas");
        }
    }
}
