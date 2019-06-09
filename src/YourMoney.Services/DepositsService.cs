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
        private const int OneValue = 1;
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
                    deposit.DepositTerm = DepositTerm.OneMonth;
                }

                this.dbContext.SaveChanges();
                return;
            }
            if (depositTerm == DepositTerm.ThreeMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForThreeMonths;
                    deposit.DepositTerm = DepositTerm.ThreeMonths;
                }

                this.dbContext.SaveChanges();
                return;
            }
            if (depositTerm == DepositTerm.SixMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForSixMonths;
                    deposit.DepositTerm = DepositTerm.SixMonths;
                }

                this.dbContext.SaveChanges();
                return;
            }
            if (depositTerm == DepositTerm.NineMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForNineMonths;
                    deposit.DepositTerm = DepositTerm.NineMonths;
                }

                this.dbContext.SaveChanges();
                return;
            }
            if (depositTerm == DepositTerm.TwelveMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForTwelveMonths;
                    deposit.DepositTerm = DepositTerm.TwelveMonths;
                }

                this.dbContext.SaveChanges();
                return;
            }
            if (depositTerm == DepositTerm.EighteenMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForEighteenMonths;
                    deposit.DepositTerm = DepositTerm.EighteenMonths;
                }

                this.dbContext.SaveChanges();
                return;
            }
            if (depositTerm == DepositTerm.TwentyFourMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForTwentyFourMonths;
                    deposit.DepositTerm = DepositTerm.TwentyFourMonths;
                }

                this.dbContext.SaveChanges();
                return;
            }
            if (depositTerm == DepositTerm.ThirtySixMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForThirtySixMonths;
                    deposit.DepositTerm = DepositTerm.ThirtySixMonths;
                }

                this.dbContext.SaveChanges();
                return;
            }
            if (depositTerm == DepositTerm.FortyEightMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForFortyEightMonths;
                    deposit.DepositTerm = DepositTerm.FortyEightMonths;
                }

                this.dbContext.SaveChanges();
                return;
            }
            if (depositTerm == DepositTerm.SixtyMonths)
            {
                foreach (var deposit in deposits)
                {
                    deposit.Interest = deposit.InterestForSixtyMonths;
                    deposit.DepositTerm = DepositTerm.SixtyMonths;
                }

                this.dbContext.SaveChanges();
                return;
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

            deposit.EffectiveAnnualInterestRate = ZeroValue;
            deposit.InterestTax = ZeroValue;
            deposit.TotalPaid = ZeroValue;
            deposit.InterestAmount = ZeroValue;
            deposit.NetPaid = ZeroValue;

            this.dbContext.SaveChanges();

            deposit.TotalPaid += deposit.Amount + (deposit.Amount * deposit.Interest / HundredPercentValue);
            deposit.InterestAmount += deposit.TotalPaid - deposit.Amount;
            deposit.InterestTax += deposit.InterestAmount * InterestTaxValue;
            deposit.NetPaid += deposit.TotalPaid - deposit.InterestTax;
            deposit.EffectiveAnnualInterestRate = ((deposit.NetPaid / deposit.Amount) - OneValue) * HundredPercentValue;

            this.dbContext.SaveChanges();
        }

        private IEnumerable<TModel> By<TModel>(Func<Deposit, bool> predicate)
            => this.dbContext.Deposits.Where(predicate).AsQueryable().ProjectTo<TModel>();

        public void Edit(int depositId, string depositName, decimal minimumAmount, decimal maximumAmount, 
            DepositType depositType, string contractualInterest, Currency currency, InterestPayment interestPayment,
            DepositFor depositFor, InterestType interestType, IncreasingAmount increasingAmount, 
            OverdraftOpportunity overdraftOpportunity, CreditOpportunity creditOpportunity, 
            InterestCapitalize interestCapitalize, string maximumMonthPeriod, string minimumMonthPeriod, 
            string validDepositDeadlines, ValidForCustomer validForCustomer, MonthlyAccrual monthlyAccrual, 
            string additionalTerms, string bonuses, int bankId, 
            decimal interestForOneMonth, decimal interestForThreeMonths, decimal interestForSixMonths,
            decimal interestForNineMonths, decimal interestForTwelveMonths, decimal interestForEighteenMonths,
            decimal interestForTwentyFourMonths, decimal interestForThirtySixMonths, decimal interestForFortyEightMonths,
            decimal interestForSixtyMonths)
        {
            var deposit = this.dbContext.Deposits.FirstOrDefault(d => d.Id == depositId);
            
            deposit.Name = depositName;
            deposit.MinimumAmount = minimumAmount;
            deposit.MaximumAmount = maximumAmount;
            deposit.DepositType = depositType;
            deposit.ContractualInterest = contractualInterest;
            deposit.Currency = currency;
            deposit.InterestPayment = interestPayment;
            deposit.DepositFor = depositFor;
            deposit.InterestType = interestType;
            deposit.IncreasingAmount = increasingAmount;
            deposit.OverdraftOpportunity = overdraftOpportunity;
            deposit.CreditOpportunity = creditOpportunity;
            deposit.InterestCapitalize = interestCapitalize;
            deposit.MaximumMonthPeriod = maximumMonthPeriod;
            deposit.MinimumMonthPeriod = minimumMonthPeriod;
            deposit.ValidDepositDeadlines = validDepositDeadlines;
            deposit.ValidForCustomer = validForCustomer;
            deposit.MonthlyAccrual = monthlyAccrual;
            deposit.AdditionalTerms = additionalTerms;
            deposit.Bonuses = bonuses;
            deposit.BankId = bankId;
            deposit.InterestForOneMonth = interestForOneMonth;
            deposit.InterestForThreeMonths = interestForThreeMonths;
            deposit.InterestForSixMonths = interestForSixMonths;
            deposit.InterestForNineMonths = interestForNineMonths;
            deposit.InterestForTwelveMonths = interestForTwelveMonths;
            deposit.InterestForTwentyFourMonths = interestForTwentyFourMonths;
            deposit.InterestForThirtySixMonths = interestForThirtySixMonths;
            deposit.InterestForFortyEightMonths = interestForFortyEightMonths;
            deposit.InterestForSixtyMonths = interestForSixtyMonths;

            this.dbContext.Update(deposit);
            this.dbContext.SaveChanges();

        }
    }
}