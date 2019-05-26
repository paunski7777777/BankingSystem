using Microsoft.EntityFrameworkCore.Migrations;

namespace YourMoney.Data.Migrations
{
    public partial class BonusPropertyDepositModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bonuses",
                table: "Deposits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bonuses",
                table: "Deposits");
        }
    }
}
