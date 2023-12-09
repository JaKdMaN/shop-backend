using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_backend.Database.Migrations
{
    public partial class add_token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_UserRoles_UserRoleId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "userRoles");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_userRoles",
                table: "userRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_userRoles_UserRoleId",
                table: "users",
                column: "UserRoleId",
                principalTable: "userRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_userRoles_UserRoleId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userRoles",
                table: "userRoles");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "users");

            migrationBuilder.RenameTable(
                name: "userRoles",
                newName: "UserRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_UserRoles_UserRoleId",
                table: "users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
