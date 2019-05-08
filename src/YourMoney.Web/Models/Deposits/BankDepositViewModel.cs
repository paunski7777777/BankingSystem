namespace YourMoney.Web.Models.Deposits
{
    using YourMoney.Models.Enums;

    public class BankDepositViewModel
    {
        public string Name { get; set; }
        public decimal MinimumAmount { get; set; }
        public double Interest { get; set; }
        public InterestPayment InterestPayment { get; set; }
    }
}