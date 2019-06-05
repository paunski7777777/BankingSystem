namespace YourMoney.Web.Models.Deposits
{
    using YourMoney.Models.Enums;

    public class DepositViewModel
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string Name { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal Interest { get; set; }
        public InterestPayment InterestPayment { get; set; }
    }
}