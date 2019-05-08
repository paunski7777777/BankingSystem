namespace YourMoney.Services.Contracts
{
    using System.Linq;

    using YourMoney.Models.Enums;

    public interface IDepositsService
    {
        IQueryable<TModel> AllCompared<TModel>(Currency currency, DepositTerm depositTerm, InterestPayment interestPayment,
            DepositFor depositFor, InterestType interestType, IncreasingAmount increasingAmount,
            OverdraftOpportunity overdraftOpportunity, CreditOpportunity creditOpportunity);
    }
}