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
            var dbContext = GetDatabase();

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
            var dbContext = GetDatabase();

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
            var dbContext = GetDatabase();

            var item = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };
            var items = new BanksService(dbContext);
            items.Add(item.Name);

            items.Remove(item.Id);

            var result = dbContext.Banks.FirstOrDefault();

            Assert.Null(result);
        }

        [Test]
        public void ExistByIdMethodShouldCheckIfThereIsBankWithThatId()
        {
            var dbContext = GetDatabase();

            var item = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };

            var items = new BanksService(dbContext);
            items.Add(item.Name);

            var result = items.ExistsById(item.Id);
            
            Assert.True(result);
        }

        [Test]
        public void ExistByNameMethodShouldCheckIfThereIsBankWithThatName()
        {
            var dbContext = GetDatabase();

            var item = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };

            var items = new BanksService(dbContext);
            items.Add(item.Name);

            var result = items.ExistsByName(item.Name);

            Assert.True(result);
        }
    }
}