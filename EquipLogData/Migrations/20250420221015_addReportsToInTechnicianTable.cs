using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipLogData.Migrations
{
    /// <inheritdoc />
    public partial class addReportsToInTechnicianTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReportsTo",
                table: "Technicians",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportsTo",
                table: "Technicians");
        }
    }
}
