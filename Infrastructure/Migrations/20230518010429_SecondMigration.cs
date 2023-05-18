using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classes_games_GameId",
                table: "classes");

            migrationBuilder.DropIndex(
                name: "IX_classes_GameId",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "games");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "classes");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "game_metrics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "game_metrics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FailureCount",
                table: "game_metrics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGameCompleted",
                table: "game_metrics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "PercentageOfCompletion",
                table: "game_metrics",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuccessCount",
                table: "game_metrics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameEntityId",
                table: "classes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classes_games_GameEntityId",
                table: "classes");

            migrationBuilder.DropIndex(
                name: "IX_classes_GameEntityId",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "game_metrics");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "game_metrics");

            migrationBuilder.DropColumn(
                name: "FailureCount",
                table: "game_metrics");

            migrationBuilder.DropColumn(
                name: "IsGameCompleted",
                table: "game_metrics");

            migrationBuilder.DropColumn(
                name: "PercentageOfCompletion",
                table: "game_metrics");

            migrationBuilder.DropColumn(
                name: "SuccessCount",
                table: "game_metrics");

            migrationBuilder.DropColumn(
                name: "GameEntityId",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "classes");

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_classes_GameId",
                table: "classes",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_classes_games_GameId",
                table: "classes",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
