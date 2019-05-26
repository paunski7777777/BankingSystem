namespace YourMoney.Web.Areas.Admin.Models.Deposits
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;
    using YourMoney.Models.Enums;

    public class AddDepositInputModel
    {
        [Required]
        [Display(Name = GlobalConstants.DepositAddDisplayName)]
        public string Name { get; set; }

        [Required]
        [Display(Name = GlobalConstants.MinimumAmountAddDisplayName)]
        public decimal MinimumAmount { get; set; }

        [Required]
        [Display(Name = GlobalConstants.MaximumAmountAddDisplayName)]
        public decimal MaximumAmount { get; set; }

        [Required]
        [Display(Name = GlobalConstants.InterestAddDisplayName)]
        public decimal Interest { get; set; }

        [Required]
        [Display(Name = GlobalConstants.TotalPaidAddDisplayName)]
        public decimal TotalPaid { get; set; }

        [Required]
        [Display(Name = GlobalConstants.InterestAmountAddDisplayName)]
        public decimal InterestAmount { get; set; }

        [Required]
        [Display(Name = GlobalConstants.InterestTaxAddDisplayName)]
        public decimal InterestTax { get; set; }

        [Required]
        [Display(Name = GlobalConstants.NetPaidAddDisplayName)]
        public decimal NetPaid { get; set; }

        [Required]
        [Display(Name = GlobalConstants.DepositTypeAddDisplayName)]
        public DepositType DepositType { get; set; }

        [Required]
        [Display(Name = GlobalConstants.ContractualInterestAddDisplayName)]
        public string ContractualInterest { get; set; }

        [Required]
        [Display(Name = GlobalConstants.CurrencyAddDisplayName)]
        public Currency Currency { get; set; }

        [Required]
        [Display(Name = GlobalConstants.DepositTermAddDisplayName)]
        public DepositTerm DepositTerm { get; set; }

        [Required]
        [Display(Name = GlobalConstants.InterestPaymentAddDisplayName)]
        public InterestPayment InterestPayment { get; set; }

        [Required]
        [Display(Name = GlobalConstants.DepositForAddDisplayName)]
        public DepositFor DepositFor { get; set; }

        [Required]
        [Display(Name = GlobalConstants.InterestTypeAddDisplayName)]
        public InterestType InterestType { get; set; }

        [Required]
        [Display(Name = GlobalConstants.IncreasingAmountAddDisplayName)]
        public IncreasingAmount IncreasingAmount { get; set; }

        [Required]
        [Display(Name = GlobalConstants.OverdraftOpportunityAddDisplayName)]
        public OverdraftOpportunity OverdraftOpportunity { get; set; }

        [Required]
        [Display(Name = GlobalConstants.CreditOpportunityAddDisplayName)]
        public CreditOpportunity CreditOpportunity { get; set; }

        [Required]
        [Display(Name = GlobalConstants.InterestCapitalizeAddDisplayName)]
        public InterestCapitalize InterestCapitalize { get; set; }

        [Required]
        [Display(Name = GlobalConstants.MaximumMonthPeriodAddDisplayName)]
        public string MaximumMonthPeriod { get; set; }

        [Required]
        [Display(Name = GlobalConstants.MinimumMonthPeriodAddDisplayName)]
        public string MinimumMonthPeriod { get; set; }

        [Required]
        [Display(Name = GlobalConstants.ValidDepositDeadlinesAddDisplayName)]
        public string ValidDepositDeadlines { get; set; }

        [Required]
        [Display(Name = GlobalConstants.ValidForCustomerAddDisplayName)]
        public ValidForCustomer ValidForCustomer { get; set; }

        [Required]
        [Display(Name = GlobalConstants.MonthlyAccrualAddDisplayName)]
        public MonthlyAccrual MonthlyAccrual { get; set; }

        [Display(Name = GlobalConstants.AdditionalTermsAddDisplayName)]
        public string AdditionalTerms { get; set; }

        [Display(Name = GlobalConstants.BonusesAddDisplayName)]
        public string Bonuses { get; set; }

        [Required]
        [Display(Name = GlobalConstants.BankAddDisplayName)]
        public int BankId { get; set; }
        public IEnumerable<SelectListItem> Banks { get; set; }
    }
}