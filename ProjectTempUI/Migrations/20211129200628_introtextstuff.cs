using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTempUI.Migrations
{
    public partial class introtextstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Letext",
                table: "Intro_Texts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Letext",
                table: "Intro_Texts");
        }
    }
}
