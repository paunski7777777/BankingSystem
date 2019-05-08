namespace YourMoney.Services
{
    using AutoMapper.QueryableExtensions;

    using System.Linq;

    using YourMoney.Data;
    using YourMoney.Models.Enums;
    using YourMoney.Services.Contracts;

    public class DepositsService : IDepositsService
    {
        private readonly ApplicationDbContext dbContext;

        public DepositsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<TModel> AllCompared<TModel>(Currency currency, DepositTerm depositTerm,
            InterestPayment interestPayment, DepositFor depositFor, InterestType interestType,
            IncreasingAmount increasingAmount, OverdraftOpportunity overdraftOpportunity,
            CreditOpportunity creditOpportunity)
            => this.dbContext.Deposits.AsQueryable().ProjectTo<TModel>();
    }
}