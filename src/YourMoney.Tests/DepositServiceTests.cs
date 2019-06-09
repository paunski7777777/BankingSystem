using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using YourMoney.Data;
using YourMoney.Models;
using YourMoney.Models.Enums;
using YourMoney.Services;
using YourMoney.Services.Contracts;
using YourMoney.Tests.Base;

namespace YourMoney.Tests
{
    public class DepositServiceTests : BaseServiceTests
    {
        private readonly IBanksService bankService;

        [Test]
        public void AddMethodShouldAddDeposit()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddDeposit_Deposits_DB")
                .Options;
            var dbContext = new ApplicationDbContext(options);

            var bank = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };
            var banks = new BanksService(dbContext);
            dbContext.Banks.Add(bank);
            var items = new DepositsService(dbContext, banks);

            items.Add("БНП Париба С.А.", 2000, 20000, DepositType.AdvancePaymentInterestDeposit,
                @"В зависимост от срока и сумата:
            За срок от 12 месеца - 0.50 % ", Currency.BGN, InterestPayment.NoMatter, DepositFor.Retirees,
                InterestType.Fixed, IncreasingAmount.No, OverdraftOpportunity.No, CreditOpportunity.No,
                InterestCapitalize.No, "36",
                "12", "12,24,36", ValidForCustomer.No, MonthlyAccrual.No, "няма", "няма", bank.Id, (decimal) 0.1,
                (decimal) 0.3, (decimal) 0.6, (decimal) 0.9,
                (decimal) 1.2, (decimal) 1.8, (decimal) 2.4, (decimal) 3.6, (decimal) 4.8, (decimal) 6);

            var result = dbContext.Deposits.Count();
            Assert.AreEqual(1, result);
        }
        [Test]
        public void RemoveMethodShouldRemoveDeposit()
        {
            var dbContext = GetDatabase();

            var bank = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };
            var banks = new BanksService(dbContext);
            dbContext.Banks.Add(bank);
            var items = new DepositsService(dbContext, banks);

            items.Add("БНП Париба С.А.", 2000, 20000, DepositType.AdvancePaymentInterestDeposit,
                @"В зависимост от срока и сумата:
            За срок от 12 месеца - 0.50 % ", Currency.BGN, InterestPayment.NoMatter, DepositFor.Retirees,
                InterestType.Fixed, IncreasingAmount.No, OverdraftOpportunity.No, CreditOpportunity.No,
                InterestCapitalize.No, "36",
                "12", "12,24,36", ValidForCustomer.No, MonthlyAccrual.No, "няма", "няма", bank.Id, (decimal)0.1,
                (decimal)0.3, (decimal)0.6, (decimal)0.9,
                (decimal)1.2, (decimal)1.8, (decimal)2.4, (decimal)3.6, (decimal)4.8, (decimal)6);

            var deposit = dbContext.Deposits.FirstOrDefault();
            items.Remove(deposit.Id);
            var result = dbContext.Deposits.Count();
            Assert.AreEqual(0, result);
        }

        [Test]
        public void EditMethodShouldEditDeposit()
        {

            var dbContext = GetDatabase();

            var bank = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };
            var banks = new BanksService(dbContext);
            dbContext.Banks.Add(bank);
            var items = new DepositsService(dbContext, banks);

            items.Add("БНП Париба С.А.", 2000, 20000, DepositType.AdvancePaymentInterestDeposit,
                @"В зависимост от срока и сумата:
            За срок от 12 месеца - 0.50 % ", Currency.BGN, InterestPayment.NoMatter, DepositFor.Retirees,
                InterestType.Fixed, IncreasingAmount.No, OverdraftOpportunity.No, CreditOpportunity.No,
                InterestCapitalize.No, "36",
                "12", "12,24,36", ValidForCustomer.No, MonthlyAccrual.No, "няма", "няма", bank.Id, (decimal)0.1,
                (decimal)0.3, (decimal)0.6, (decimal)0.9,
                (decimal)1.2, (decimal)1.8, (decimal)2.4, (decimal)3.6, (decimal)4.8, (decimal)6);

            var deposit = dbContext.Deposits.FirstOrDefault();

            items.Edit(deposit.Id, "DSK", 2000, 20000, DepositType.AdvancePaymentInterestDeposit,
                @"В зависимост от срока и сумата:
            За срок от 12 месеца - 0.50 % ", Currency.BGN, InterestPayment.NoMatter, DepositFor.Retirees,
                InterestType.Fixed, IncreasingAmount.No, OverdraftOpportunity.No, CreditOpportunity.No,
                InterestCapitalize.No, "36",
                "12", "12,24,36", ValidForCustomer.No, MonthlyAccrual.No, "няма", "няма", bank.Id, (decimal)0.1,
                (decimal)0.3, (decimal)0.6, (decimal)0.9,
                (decimal)1.2, (decimal)1.8, (decimal)2.4, (decimal)3.6, (decimal)4.8, (decimal)6);

            var result = dbContext.Deposits.FirstOrDefault(x => x.Name == "DSK");
            Assert.NotNull(result);
        }

        [Test]
        public void CalculateMethodShouldCalculateDeposit()
        {
            var dbContext = GetDatabase();

            var bank = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };
            var banks = new BanksService(dbContext);
            dbContext.Banks.Add(bank);
            var items = new DepositsService(dbContext, banks);

            items.Add("БНП Париба С.А.", 2000, 20000, DepositType.AdvancePaymentInterestDeposit,
                @"В зависимост от срока и сумата:
            За срок от 12 месеца - 0.50 % ", Currency.BGN, InterestPayment.NoMatter, DepositFor.Retirees,
                InterestType.Fixed, IncreasingAmount.No, OverdraftOpportunity.No, CreditOpportunity.No,
                InterestCapitalize.No, "36",
                "12", "12,24,36", ValidForCustomer.No, MonthlyAccrual.No, "няма", "няма", bank.Id, (decimal)0.1,
                (decimal)0.3, (decimal)0.6, (decimal)0.9,
                (decimal)1.2, (decimal)1.8, (decimal)2.4, (decimal)3.6, (decimal)4.8, (decimal)6);

            var deposit = dbContext.Deposits.FirstOrDefault();
            deposit.Amount = 4;
            items.CalculateDeposit(deposit.Id);

            var result = deposit.TotalPaid;

            Assert.AreEqual(4, result);
        }
    }
}
