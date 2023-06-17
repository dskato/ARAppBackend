using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class MClassUserMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserListId",
                table: "classes",
                newName: "Code");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "m_class_user",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_class_user", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_m_class_user_classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "classes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_m_class_user_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_class_user_UserId",
                table: "m_class_user",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_class_user");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "games");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "classes",
                newName: "UserListId");
        }
    }
}
