using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Migrations
{
    /// <inheritdoc />
    public partial class useraddtokenfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "Kullanıcılar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExprationToken",
                table: "Kullanıcılar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Kullanıcılar",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "Kullanıcılar");

            migrationBuilder.DropColumn(
                name: "ExprationToken",
                table: "Kullanıcılar");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Kullanıcılar");
        }
    }
}
