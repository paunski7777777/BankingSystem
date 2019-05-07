namespace YourMoney.Web.Models.Banks
{
    using System;

    using YourMoney.Models.Enums;

    public class BankViewModel
    {
        public string BankName { get; set; }
        public string DepositName { get; set; }
        public decimal DepositMinimumAmount { get; set; }
        public decimal DepositInterest { get; set; }
        public InterestPayment DepositInterestPayment { get; set; }
    }
}