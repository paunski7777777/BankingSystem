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
        private const int HundredPercentValue = 100;
        private const int ZeroValue = 0;
        private const decimal InterestTaxValue = 0.08m;

        private readonly ApplicationDbContext dbContext;
        private readonly IBanksService banksService;

        public DepositsService(ApplicationDbContext dbContext, IBanksService banksService)
        {
            this.dbContext = dbContext;
            this.banksService = banksService;
        }

        public void Add(string depositName, decimal minimumAmount, decimal maximumAmount, DepositType depositType,
            string contractualInterest, Currency currency, InterestPayment interestPayment, DepositFor depositFor,
            InterestType interestType, IncreasingAmount increasingAmount, OverdraftOpportunity overdraftOpportunity,
            CreditOpportunity creditOpportunity, InterestCapitalize interestCapitalize, string maximumMonthPeriod,
            string minimumMonthPeriod, string validDepositDeadlines, ValidForCustomer validForCustomer,
            MonthlyAccrual monthlyAccrual, string additionalTerms, string bonuses, int bankId,
            decimal interestForOneMonth, decimal interestForThreeMonths, decimal interestForSixMonths,
            decimal interestForNineMonths, decimal interestForTwelveMonths, decimal interestForEighteenMonths,
            decimal interestForTwentyFourMonths, decimal interestForThirtySixMonths, decimal interestForFortyEightMonths,
            decimal interestForSixtyMonths)
        {
            var bank = this.banksService.GetById<Bank>(bankId);

            var deposit = new Deposit
            {
                Name = depositName,
                MinimumAmount = minimumAmount,
                MaximumAmount = maximumAmount,
                DepositType = depositType,
                ContractualInterest = contractualInterest,
                Currency = currency,
                InterestPayment = interestPayment,
                InterestType = interestType,
                IncreasingAmount = increasingAmount,
                DepositFor = depositFor,
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
                Bank = bank,
                InterestForOneMonth = interestForOneMonth,
                InterestForThreeMonths = interestForThreeMonths,
                InterestForSixMonths = interestForSixMonths,
                InterestForNineMonths = interestForNineMonths,
                InterestForTwelveMonths = interestForTwelveMonths,
                InterestForEighteenMonths = interestForEighteenMonths,
                InterestForTwentyFourMonths = interestForTwentyFourMonths,
                InterestForThirtySixMonths = interestForThirtySixMonths,
                InterestForFortyEightMonths = interestForFortyEightMonths,
                InterestForSixtyMonths = interestForSixtyMonths
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

        public IQueryable<TModel> Compared<TModel>(decimal amount, Currency currency, DepositTerm depositTerm,
            InterestPayment interestPayment, DepositFor depositFor, InterestType interestType,
            IncreasingAmount increasingAmount, OverdraftOpportunity overdraftOpportunity,
            CreditOpportunity creditOpportunity)
        {
            var deposits = this.dbContext.Deposits.Where(d => d.Currency == currency);

            this.SetAmountForDeposits(amount, deposits);
            this.SetInterestValueByDepositTerm(depositTerm, deposits);

            deposits = deposits.Where(d => d.MinimumAmount <= amount && d.MaximumAmount >= amount);

            deposits = this.FilterDepositsByDepositProperties(interestPayment, depositFor, interestType, increasingAmount, overdraftOpportunity, creditOpportunity, deposits);

            var compared = deposits.AsQueryable().ProjectTo<TModel>();

            return compared;
        }

        private IQueryable<Deposit> FilterDepositsByDepositProperties(InterestPayment interestPayment, DepositFor depositFor, InterestType interestType, IncreasingAmount increasingAmount, OverdraftOpportunity overdraftOpportunity, CreditOpportunity creditOpportunity, IQueryable<Deposit> deposits)
        {
            if (interestPayment != InterestPayment.NoMatter)
            {
                deposits = deposits.Where(d => d.InterestPayment == interestPayment);
            }
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

            return deposits;
        }

        private void SetInterestValueByDepositTerm(DepositTerm depositTerm, IQueryable<Deposit> deposits)
        {
            if (depositTerm == DepositTerm.OneMonth)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForOneMonth;
                }

                this.dbContext.SaveChanges();
            }
            if (depositTerm == DepositTerm.ThreeMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForThreeMonths;
                }

                this.dbContext.SaveChanges();
            }
            if (depositTerm == DepositTerm.SixMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForSixMonths;
                }

                this.dbContext.SaveChanges();
            }
            if (depositTerm == DepositTerm.NineMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForNineMonths;
                }

                this.dbContext.SaveChanges();
            }
            if (depositTerm == DepositTerm.TwelveMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForTwelveMonths;
                }

                this.dbContext.SaveChanges();
            }
            if (depositTerm == DepositTerm.EighteenMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForEighteenMonths;
                }

                this.dbContext.SaveChanges();
            }
            if (depositTerm == DepositTerm.TwentyFourMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForTwentyFourMonths;
                }

                this.dbContext.SaveChanges();
            }
            if (depositTerm == DepositTerm.ThirtySixMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForThirtySixMonths;
                }

                this.dbContext.SaveChanges();
            }
            if (depositTerm == DepositTerm.FortyEightMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForFortyEightMonths;
                }

                this.dbContext.SaveChanges();

            }
            if (depositTerm == DepositTerm.SixtyMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForSixtyMonths;
                }

                this.dbContext.SaveChanges();
            }
        }

        private void SetAmountForDeposits(decimal amount, IQueryable<Deposit> deposits)
        {
            foreach (var deposit in deposits)
            {
                deposit.Amount = amount;
            }

            this.dbContext.SaveChanges();
        }

        public void CalculateDeposit(int depositId)
        {
            var deposit = this.dbContext.Deposits.FirstOrDefault(d => d.Id == depositId);

            deposit.InterestTax = ZeroValue;
            deposit.TotalPaid = ZeroValue;
            deposit.InterestAmount = ZeroValue;
            deposit.NetPaid = ZeroValue;

            this.dbContext.SaveChanges();

            deposit.TotalPaid += deposit.Amount + (deposit.Amount * deposit.Interest / HundredPercentValue);
            deposit.InterestAmount += deposit.TotalPaid - deposit.Amount;
            deposit.InterestTax += deposit.InterestAmount * InterestTaxValue;
            deposit.NetPaid += deposit.TotalPaid - deposit.InterestTax;

            this.dbContext.SaveChanges();
        }

        private IEnumerable<TModel> By<TModel>(Func<Deposit, bool> predicate)
            => this.dbContext.Deposits.Where(predicate).AsQueryable().ProjectTo<TModel>();
    }
}