using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourMoney.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    MinimumAmount = table.Column<decimal>(nullable: false),
                    MaximumAmount = table.Column<decimal>(nullable: false),
                    Interest = table.Column<double>(nullable: false),
                    DepositType = table.Column<string>(nullable: true),
                    ContractualInterest = table.Column<string>(nullable: true),
                    Currency = table.Column<int>(nullable: false),
                    DepositTerm = table.Column<int>(nullable: false),
                    InterestPayment = table.Column<int>(nullable: false),
                    DepositFor = table.Column<int>(nullable: false),
                    InterestType = table.Column<int>(nullable: false),
                    IncreasingAmount = table.Column<int>(nullable: false),
                    OverdraftOpportunity = table.Column<int>(nullable: false),
                    CreditOpportunity = table.Column<int>(nullable: false),
                    InterestCapitalize = table.Column<int>(nullable: false),
                    MaximumMonthPeriod = table.Column<string>(nullable: true),
                    MinimumMonthPeriod = table.Column<string>(nullable: true),
                    ValidDepositDeadlines = table.Column<string>(nullable: true),
                    ValidForCustomer = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposits_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_BankId",
                table: "Deposits",
                column: "BankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
