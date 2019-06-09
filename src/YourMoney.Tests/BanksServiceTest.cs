using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using YourMoney.Data;
using YourMoney.Models;
using YourMoney.Services;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void AddMethodShouldAddBank()
        {
            var dbContext = YourMoney.Tests.Base.BaseServiceTests.GetDatabase();

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
            var dbContext = YourMoney.Tests.Base.BaseServiceTests.GetDatabase();

            var item = new Bank()
            {
                Id = 1,
                Name = "ProCredit"
            };
            var items = new BanksService(dbContext);
            items.Add(item.Name);
            items.Edit(item.Id,"DSK");

            var result = dbContext.Banks.FirstOrDefault(x => x.Name == "DSK");
            
            Assert.AreEqual("DSK",result.Name);
        }
    }
}