namespace YourMoney.Web.Models.Deposits
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;
    using YourMoney.Models.Enums;

    public class DetailsDepositViewModel
    {
        public int Id { get; set; }

        [Display(Name = GlobalConstants.DepositDetailsDislpayName)]
        public string Name { get; set; }

        [Display(Name = GlobalConstants.BankDetailsDisplayName)]
        public string BankName { get; set; }

        [Display(Name = GlobalConstants.DepositTypeAddDisplayName)]
        public DepositType DepositType { get; set; }

        [Display(Name = GlobalConstants.ContractualInterestAddDisplayName)]
        public string ContractualInterest { get; set; }

        [Display(Name = GlobalConstants.InterestTypeAddDisplayName)]
        public InterestType InterestType { get; set; }

        [Display(Name = GlobalConstants.InterestCapitalizeAddDisplayName)]
        public InterestCapitalize InterestCapitalize { get; set; }

        [Display(Name = GlobalConstants.InterestPaymentAddDisplayName)]
        public InterestPayment InterestPayment { get; set; }

        [Display(Name = GlobalConstants.MonthlyAccrualAddDisplayName)]
        public MonthlyAccrual MonthlyAccrual { get; set; }

        [Display(Name = GlobalConstants.CurrencyAddDisplayName)]
        public Currency Currency { get; set; }

        [Display(Name = GlobalConstants.DepositForAddDisplayName)]
        public DepositFor DepositFor { get; set; }

        [Display(Name = GlobalConstants.MaximumAmountAddDisplayName)]
        public decimal MaximumAmount { get; set; }

        [Display(Name = GlobalConstants.MinimumAmountAddDisplayName)]
        public decimal MinimumAmount { get; set; }

        [Display(Name = GlobalConstants.MaximumMonthPeriodAddDisplayName)]
        public string MaximumMonthPeriod { get; set; }

        [Display(Name = GlobalConstants.MinimumMonthPeriodAddDisplayName)]
        public string MinimumMonthPeriod { get; set; }

        [Display(Name = GlobalConstants.ValidDepositDeadlinesAddDisplayName)]
        public string ValidDepositDeadlines { get; set; }

        [Display(Name = GlobalConstants.ValidForCustomerAddDisplayName)]
        public ValidForCustomer ValidForCustomer { get; set; }

        [Display(Name = GlobalConstants.CreditOpportunityAddDisplayName)]
        public CreditOpportunity CreditOpportunity { get; set; }

        [Display(Name = GlobalConstants.OverdraftOpportunityAddDisplayName)]
        public OverdraftOpportunity OverdraftOpportunity { get; set; }

        [Display(Name = GlobalConstants.IncreasingAmountAddDisplayName)]
        public IncreasingAmount IncreasingAmount { get; set; }

        [Display(Name = GlobalConstants.AdditionalTermsAddDisplayName)]
        public string AdditionalTerms { get; set; }

        [Display(Name = GlobalConstants.BonusesAddDisplayName)]
        public string Bonuses { get; set; }
    }
}