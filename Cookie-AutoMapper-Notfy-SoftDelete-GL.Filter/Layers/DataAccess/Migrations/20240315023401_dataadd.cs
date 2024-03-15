using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Migrations
{
    /// <inheritdoc />
    public partial class dataadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dosya",
                table: "Mesajlar",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Mesajlar",
                newName: "Dosya");
        }
    }
}
