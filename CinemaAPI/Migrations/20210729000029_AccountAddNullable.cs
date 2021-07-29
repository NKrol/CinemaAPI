using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaAPI.Migrations
{
    public partial class AccountAddNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DetailsAccounts_DetailsAccountId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "DetailsAccountId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DetailsAccounts_DetailsAccountId",
                table: "Users",
                column: "DetailsAccountId",
                principalTable: "DetailsAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_DetailsAccounts_DetailsAccountId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "DetailsAccountId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DetailsAccounts_DetailsAccountId",
                table: "Users",
                column: "DetailsAccountId",
                principalTable: "DetailsAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
