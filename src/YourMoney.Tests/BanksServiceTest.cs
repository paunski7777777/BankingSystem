using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using YourMoney.Data;
using YourMoney.Models;
using YourMoney.Services;
using YourMoney.Tests.Base;

namespace Tests
{
    public class Tests : BaseServiceTests
    {
        [Test]
        public void AddMethodShouldAddBank()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddBank_Banks_DB")
                .Options;

            var dbContext = new ApplicationDbContext(options);

            var item = new Bank()
            {
                Name = "ProCredit"
            };

            var items = new BanksService(dbContext);
            items.Add(item.Name);
            var result = dbContext.Banks.Count();


            Assert.AreEqual(1, result);
        }

        [Test]
        public void EditMethodShouldEditBank()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddBank_Banks_DB")
                .Options;

            var dbContext = new ApplicationDbContext(options);

            var item = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };

            var items = new BanksService(dbContext);
            items.Add(item.Name);
            items.Edit(item.Id, "DSK");

            var result = dbContext.Banks.FirstOrDefault(x => x.Name == "DSK");

            Assert.AreEqual("DSK", result.Name);
        }

        [Test]
        public void RemoveMethodShouldRemoveBank()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddBank_Banks_DB")
                .Options;
            var dbContext = new ApplicationDbContext(options);

            var item = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };
            var items = new BanksService(dbContext);
            items.Add(item.Name);

            items.Remove(item.Id);

            var result = dbContext.Banks.FirstOrDefault(b => b.Id == item.Id);

            Assert.Null(result);

        }
        [Test]
        public void ExistByIdMethodShouldCheckIfThereIsBankWithThatId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddBank_Banks_DB")
                .Options;

            var dbContext = new ApplicationDbContext(options);

            var bank = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };

            var banksService = new BanksService(dbContext);

            banksService.Add(bank.Name);

            var result = banksService.ExistsById(bank.Id);

            Assert.True(result);
        }

        [Test]
        public void ExistByNameMethodShouldCheckIfThereIsBankWithThatName()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ExistsNameBank_Banks_DB")
                .Options;

            var dbContext = new ApplicationDbContext(options);

            var bank = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };

            var banksService = new BanksService(dbContext);
            banksService.Add(bank.Name);

            var result = banksService.ExistsByName(bank.Name);

            Assert.True(result);
        }
    }
    
}