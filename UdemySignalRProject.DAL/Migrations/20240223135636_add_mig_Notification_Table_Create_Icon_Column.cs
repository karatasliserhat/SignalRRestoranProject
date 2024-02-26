using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemySignalRProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_Notification_Table_Create_Icon_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Notifications");
        }
    }
}
