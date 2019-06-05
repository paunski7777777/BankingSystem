namespace YourMoney.Services.Contracts
{
    using System.Linq;

    using YourMoney.Models.Enums;

    public interface IDepositsService
    {
        void Add(string depositName, decimal MinimumAmount, decimal MaximumAmount, DepositType DepositType,
            string ContractualInterest, Currency Currency, InterestPayment InterestPayment, DepositFor DepositFor,
            InterestType InterestType, IncreasingAmount IncreasingAmount, OverdraftOpportunity OverdraftOpportunity,
            CreditOpportunity CreditOpportunity, InterestCapitalize InterestCapitalize, string MaximumMonthPeriod,
            string MinimumMonthPeriod, string ValidDepositDeadlines, ValidForCustomer ValidForCustomer,
            MonthlyAccrual MonthlyAccrual, string AdditionalTerms, string bonuses, int BankId,
            decimal interestForOneMonth, decimal interestForThreeMonths, decimal interestForSixMonths,
            decimal interestForNineMonths, decimal interestForTwelveMonths, decimal interestForEighteenMonths,
            decimal interestForTwentyFourMonths, decimal interestForThirtySixMonths, decimal interestForFortyEightMonths,
            decimal interestForSixtyMonths);

        void Remove(int depositId);
        bool ExistsById(int depositId);
        bool ExistsByName(string depositName);
        TModel GetById<TModel>(int depositId);
        IQueryable<TModel> All<TModel>();

        IQueryable<TModel> Compared<TModel>(decimal amount, Currency currency, DepositTerm depositTerm, InterestPayment interestPayment,
            DepositFor depositFor, InterestType interestType, IncreasingAmount increasingAmount,
            OverdraftOpportunity overdraftOpportunity, CreditOpportunity creditOpportunity);

        void CalculateDeposit(int depositId);
    }
}