namespace YourMoney.Web.Models.Deposits
{
    using YourMoney.Models.Enums;

    public class ComparedDepositViewModel
    {
        public string BankName { get; set; }
        public string Name { get; set; }
        public double Interest { get; set; }
        public decimal MinimumAmount { get; set; }
        public InterestType InterestType { get; set; }
    }
}