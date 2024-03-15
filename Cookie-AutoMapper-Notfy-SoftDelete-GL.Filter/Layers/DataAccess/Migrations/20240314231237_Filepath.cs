using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Migrations
{
    /// <inheritdoc />
    public partial class Filepath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Mesajlar",
                newName: "FilePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Mesajlar",
                newName: "Path");
        }
    }
}
