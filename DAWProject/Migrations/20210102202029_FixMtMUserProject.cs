using Microsoft.EntityFrameworkCore.Migrations;

namespace DAWProject.Migrations
{
    public partial class FixMtMUserProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Project_UserId",
                table: "UserProject");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectId",
                table: "UserProject",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Project_ProjectId",
                table: "UserProject",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_Project_ProjectId",
                table: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_UserProject_ProjectId",
                table: "UserProject");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_Project_UserId",
                table: "UserProject",
                column: "UserId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
