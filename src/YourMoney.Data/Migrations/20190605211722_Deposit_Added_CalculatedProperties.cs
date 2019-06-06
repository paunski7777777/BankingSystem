using Microsoft.EntityFrameworkCore.Migrations;

namespace YourMoney.Data.Migrations
{
    public partial class Deposit_Added_CalculatedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EffectiveAnnualInterestRate",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffectiveAnnualInterestRate",
                table: "Deposits");
        }
    }
}
