﻿namespace YourMoney.Models
{
    using YourMoney.Models.Enums;

    public class Deposit
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal MaximumAmount { get; set; }

        public DepositType DepositType { get; set; }
        public string ContractualInterest { get; set; }

        public Currency Currency { get; set; }
        public InterestPayment InterestPayment { get; set; }
        public DepositFor DepositFor { get; set; }
        public InterestType InterestType { get; set; }
        public IncreasingAmount IncreasingAmount { get; set; }
        public OverdraftOpportunity OverdraftOpportunity { get; set; }
        public CreditOpportunity CreditOpportunity { get; set; }
        public InterestCapitalize InterestCapitalize { get; set; }

        public string MaximumMonthPeriod { get; set; }
        public string MinimumMonthPeriod { get; set; }
        public string ValidDepositDeadlines { get; set; }
        public ValidForCustomer ValidForCustomer { get; set; }
        public MonthlyAccrual MonthlyAccrual { get; set; }
        public string AdditionalTerms { get; set; }
        public string Bonuses { get; set; }

        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }

        public decimal Amount { get; set; }
        public decimal Interest { get; set; }

        public decimal InterestForOneMonth { get; set; }
        public decimal InterestForThreeMonths { get; set; }
        public decimal InterestForSixMonths { get; set; }
        public decimal InterestForNineMonths { get; set; }
        public decimal InterestForTwelveMonths { get; set; }
        public decimal InterestForEighteenMonths { get; set; }
        public decimal InterestForTwentyFourMonths { get; set; }
        public decimal InterestForThirtySixMonths { get; set; }
        public decimal InterestForFortyEightMonths { get; set; }
        public decimal InterestForSixtyMonths { get; set; }

        public decimal EffectiveAnnualInterestRate { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal InterestTax { get; set; }
        public decimal NetPaid { get; set; }

        public DepositTerm DepositTerm { get; set; }
    }
}