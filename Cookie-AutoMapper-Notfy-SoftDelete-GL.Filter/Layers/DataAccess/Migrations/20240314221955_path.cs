using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Migrations
{
    /// <inheritdoc />
    public partial class path : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Mesajlar",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Mesajlar");
        }
    }
}
