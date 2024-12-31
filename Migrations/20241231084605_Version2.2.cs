using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RettioApi.Migrations
{
    /// <inheritdoc />
    public partial class Version22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "Appointment",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "Appointment");
        }
    }
}
