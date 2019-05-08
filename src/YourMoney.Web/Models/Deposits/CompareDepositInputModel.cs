namespace YourMoney.Web.Models.Deposits
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;
    using YourMoney.Models.Enums;

    public class CompareDepositInputModel
    {
        [Display(Name = GlobalConstants.AmountDisplayName)]
        public decimal Amount { get; set; }

        [Display(Name = GlobalConstants.CurrencyDisplayName)]
        public Currency Currency { get; set; }

        [Display(Name = GlobalConstants.DepositTermDisplayName)]
        public DepositTerm DepositTerm { get; set; }

        [Display(Name = GlobalConstants.InterestPaymentDisplayName)]
        public InterestPayment InterestPayment { get; set; }

        [Display(Name = GlobalConstants.DepositForDisplayName)]
        public DepositFor DepositFor { get; set; }

        [Display(Name = GlobalConstants.InterestTypeDisplayName)]
        public InterestType InterestType { get; set; }

        [Display(Name = GlobalConstants.IncreasingAmountDisplayName)]
        public IncreasingAmount IncreasingAmount { get; set; }

        [Display(Name = GlobalConstants.OverdraftOpportunityDisplayName)]
        public OverdraftOpportunity OverdraftOpportunity { get; set; }

        [Display(Name = GlobalConstants.CreditOpportunityDisplayName)]
        public CreditOpportunity CreditOpportunity { get; set; }
    }
}