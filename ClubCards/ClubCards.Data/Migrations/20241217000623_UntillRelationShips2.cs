using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubCards.Data.Migrations
{
    public partial class UntillRelationShips2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCard",
                table: "BuyingsList");

            migrationBuilder.DropColumn(
                name: "IdStore",
                table: "BuyingsList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCard",
                table: "BuyingsList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdStore",
                table: "BuyingsList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
