using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vigilant_umbrella_infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CitiesComplment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cities");
        }
    }
}
