using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemySignalRProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_booking_description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Bookings");
        }
    }
}
