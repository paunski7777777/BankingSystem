namespace YourMoney.Services
{
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using YourMoney.Data;
    using YourMoney.Models;
    using YourMoney.Models.Enums;
    using YourMoney.Services.Contracts;

    public class DepositsService : IDepositsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IBanksService banksService;

        public DepositsService(ApplicationDbContext dbContext, IBanksService banksService)
        {
            this.dbContext = dbContext;
            this.banksService = banksService;
        }

        public void Add(string depositName, decimal minimumAmount, decimal maximumAmount, decimal interest,
            decimal totalPaid, decimal interestAmount, decimal interestTax, decimal netPaid, DepositType depositType,
            string contractualInterest, Currency currency, DepositTerm depositTerm, InterestPayment interestPayment,
            DepositFor depositFor, InterestType interestType, IncreasingAmount increasingAmount,
            OverdraftOpportunity overdraftOpportunity, CreditOpportunity creditOpportunity,
            InterestCapitalize interestCapitalize, string maximumMonthPeriod, string minimumMonthPeriod,
            string validDepositDeadlines, ValidForCustomer validForCustomer, MonthlyAccrual monthlyAccrual,
            string additionalTerms, string bonuses, int bankId)
        {
            var bank = this.banksService.GetById<Bank>(bankId);

            var deposit = new Deposit
            {
                Name = depositName,
                MinimumAmount = minimumAmount,
                MaximumAmount = maximumAmount,
                Interest = interest,
                TotalPaid = totalPaid,
                InterestAmount = interestAmount,
                InterestTax = interestTax,
                NetPaid = netPaid,
                DepositType = depositType,
                ContractualInterest = contractualInterest,
                Currency = currency,
                DepositTerm = depositTerm,
                InterestPayment = interestPayment,
                OverdraftOpportunity = overdraftOpportunity,
                CreditOpportunity = creditOpportunity,
                InterestCapitalize = interestCapitalize,
                MaximumMonthPeriod = maximumMonthPeriod,
                MinimumMonthPeriod = minimumMonthPeriod,
                ValidDepositDeadlines = validDepositDeadlines,
                ValidForCustomer = validForCustomer,
                MonthlyAccrual = monthlyAccrual,
                AdditionalTerms = additionalTerms,
                Bonuses = bonuses,
                Bank = bank
            };

            this.dbContext.Deposits.Add(deposit);
            this.dbContext.SaveChanges();
        }

        public void Remove(int depositId)
        {
            var deposit = this.dbContext.Deposits.FirstOrDefault(d => d.Id == depositId);

            this.dbContext.Deposits.Remove(deposit);
            this.dbContext.SaveChanges();
        }

        public bool ExistsById(int depositId)
        => this.dbContext.Deposits.Any(d => d.Id == depositId);

        public bool ExistsByName(string depositName)
             => this.dbContext.Deposits.Any(d => d.Name == depositName);

        public TModel GetById<TModel>(int depositId)
            => this.By<TModel>(t => t.Id == depositId).SingleOrDefault();

        public IQueryable<TModel> All<TModel>()
        => this.dbContext.Deposits.AsQueryable().ProjectTo<TModel>();

        public IEnumerable<Deposit> Compared(decimal amount, Currency currency, DepositTerm depositTerm, InterestPayment interestPayment,
        DepositFor depositFor, InterestType interestType, IncreasingAmount increasingAmount,
        OverdraftOpportunity overdraftOpportunity, CreditOpportunity creditOpportunity)
        {
            var deposits = this.dbContext.Deposits.Where(d => d.Currency == currency);

            deposits = deposits.Where(d => d.InterestPayment == interestPayment);
            deposits = deposits.Where(d => d.MinimumAmount <= amount && d.MaximumAmount >= amount);

            if (depositFor != DepositFor.NoMatter)
            {
                deposits = deposits.Where(d => d.DepositFor == depositFor);
            }
            if (interestType != InterestType.NoMatter)
            {
                deposits = deposits.Where(d => d.InterestType == interestType);
            }
            if (increasingAmount != IncreasingAmount.NoMatter)
            {
                deposits = deposits.Where(d => d.IncreasingAmount == increasingAmount);
            }
            if (overdraftOpportunity != OverdraftOpportunity.NoMatter)
            {
                deposits = deposits.Where(d => d.OverdraftOpportunity == overdraftOpportunity);
            }
            if (creditOpportunity != CreditOpportunity.NoMatter)
            {
                deposits = deposits.Where(d => d.CreditOpportunity == creditOpportunity);
            }

            var compared = deposits.ToList();

            return compared;
        }

        private IEnumerable<TModel> By<TModel>(Func<Deposit, bool> predicate)
            => this.dbContext.Deposits.Where(predicate).AsQueryable().ProjectTo<TModel>();
    }
}