using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class MCUKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_m_class_user",
                table: "m_class_user");

            migrationBuilder.DropIndex(
                name: "IX_m_class_user_UserId",
                table: "m_class_user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_m_class_user",
                table: "m_class_user",
                columns: new[] { "UserId", "ClassId" });

            migrationBuilder.CreateIndex(
                name: "IX_m_class_user_ClassId",
                table: "m_class_user",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_m_class_user",
                table: "m_class_user");

            migrationBuilder.DropIndex(
                name: "IX_m_class_user_ClassId",
                table: "m_class_user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_m_class_user",
                table: "m_class_user",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_m_class_user_UserId",
                table: "m_class_user",
                column: "UserId");
        }
    }
}
