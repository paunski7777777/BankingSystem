using Microsoft.EntityFrameworkCore.Migrations;

namespace YourMoney.Data.Migrations
{
    public partial class Deposit_EditModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InterestForEighteenMonths",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestForFortyEightMonths",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestForNineMonths",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestForOneMonth",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestForSixMonths",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestForSixtyMonths",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestForThirtySixMonths",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestForThreeMonths",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestForTwelveMonths",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestForTwentyFourMonths",
                table: "Deposits",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestForEighteenMonths",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "InterestForFortyEightMonths",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "InterestForNineMonths",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "InterestForOneMonth",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "InterestForSixMonths",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "InterestForSixtyMonths",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "InterestForThirtySixMonths",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "InterestForThreeMonths",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "InterestForTwelveMonths",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "InterestForTwentyFourMonths",
                table: "Deposits");
        }
    }
}
