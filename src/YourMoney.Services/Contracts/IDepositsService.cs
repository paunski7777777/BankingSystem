namespace YourMoney.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using YourMoney.Models;
    using YourMoney.Models.Enums;

    public interface IDepositsService
    {
        void Add(string depositName, decimal MinimumAmount, decimal MaximumAmount, decimal Interest, decimal TotalPaid,
            decimal InterestAmount, decimal InterestTax, decimal NetPaid, DepositType DepositType,
            string ContractualInterest, Currency Currency, DepositTerm DepositTerm, InterestPayment InterestPayment,
            DepositFor DepositFor, InterestType InterestType, IncreasingAmount IncreasingAmount,
            OverdraftOpportunity OverdraftOpportunity, CreditOpportunity CreditOpportunity,
            InterestCapitalize InterestCapitalize, string MaximumMonthPeriod, string MinimumMonthPeriod,
            string ValidDepositDeadlines, ValidForCustomer ValidForCustomer, MonthlyAccrual MonthlyAccrual,
            string AdditionalTerms, string bonuses, int BankId);

        void Remove(int depositId);
        bool ExistsById(int depositId);
        bool ExistsByName(string depositName);
        TModel GetById<TModel>(int depositId);
        IQueryable<TModel> All<TModel>();

        IEnumerable<Deposit> Compared(decimal amount, Currency currency, DepositTerm depositTerm, InterestPayment interestPayment,
            DepositFor depositFor, InterestType interestType, IncreasingAmount increasingAmount,
            OverdraftOpportunity overdraftOpportunity, CreditOpportunity creditOpportunity);
    }
}