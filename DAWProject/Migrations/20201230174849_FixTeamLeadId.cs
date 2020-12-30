using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAWProject.Migrations
{
    public partial class FixTeamLeadId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Team_TeamId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TeamId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamLeaderId",
                table: "Team",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TeamLeaderId1",
                table: "Team",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Team_TeamLeaderId1",
                table: "Team",
                column: "TeamLeaderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_User_TeamLeaderId1",
                table: "Team",
                column: "TeamLeaderId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_User_TeamLeaderId1",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_TeamLeaderId1",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TeamLeaderId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "TeamLeaderId1",
                table: "Team");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId1",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_TeamId1",
                table: "User",
                column: "TeamId1",
                unique: true,
                filter: "[TeamId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Team_TeamId1",
                table: "User",
                column: "TeamId1",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
