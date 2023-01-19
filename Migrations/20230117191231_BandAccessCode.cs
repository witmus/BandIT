using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BandIT.Migrations
{
    public partial class BandAccessCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessCode",
                table: "Bands",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessCode",
                table: "Bands");
        }
    }
}
