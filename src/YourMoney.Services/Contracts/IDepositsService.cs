namespace YourMoney.Services.Contracts
{
    using System.Linq;

    using YourMoney.Models.Enums;

    public interface IDepositsService
    {
        void Add(string depositName, decimal minimumAmount, decimal maximumAmount, DepositType depositType,
            string contractualInterest, Currency currency, InterestPayment interestPayment, DepositFor depositFor,
            InterestType interestType, IncreasingAmount increasingAmount, OverdraftOpportunity overdraftOpportunity,
            CreditOpportunity creditOpportunity, InterestCapitalize interestCapitalize, string maximumMonthPeriod,
            string minimumMonthPeriod, string validDepositDeadlines, ValidForCustomer validForCustomer,
            MonthlyAccrual monthlyAccrual, string additionalTerms, string bonuses, int bankId,
            decimal interestForOneMonth, decimal interestForThreeMonths, decimal interestForSixMonths,
            decimal interestForNineMonths, decimal interestForTwelveMonths, decimal interestForEighteenMonths,
            decimal interestForTwentyFourMonths, decimal interestForThirtySixMonths, decimal interestForFortyEightMonths,
            decimal interestForSixtyMonths);

        void Edit(int depositId, string depositName, decimal minimumAmount, decimal maximumAmount, DepositType depositType,
            string contractualInterest, Currency currency, InterestPayment interestPayment, DepositFor depositFor,
            InterestType interestType, IncreasingAmount increasingAmount, OverdraftOpportunity overdraftOpportunity,
            CreditOpportunity creditOpportunity, InterestCapitalize interestCapitalize, string maximumMonthPeriod,
            string minimumMonthPeriod, string validDepositDeadlines, ValidForCustomer validForCustomer,
            MonthlyAccrual monthlyAccrual, string additionalTerms, string bonuses, int bankId,
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