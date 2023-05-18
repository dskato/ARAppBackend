using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classes_games_GameEntityId",
                table: "classes");

            migrationBuilder.DropIndex(
                name: "IX_classes_GameEntityId",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "GameEntityId",
                table: "classes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameEntityId",
                table: "classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_classes_GameEntityId",
                table: "classes",
                column: "GameEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_classes_games_GameEntityId",
                table: "classes",
                column: "GameEntityId",
                principalTable: "games",
                principalColumn: "Id");
        }
    }
}
