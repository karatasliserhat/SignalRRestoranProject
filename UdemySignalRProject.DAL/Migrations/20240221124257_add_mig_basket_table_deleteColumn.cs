using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemySignalRProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_basket_table_deleteColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Baskets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
