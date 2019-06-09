using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using YourMoney.Data;
using YourMoney.Web.Infrastructure;

namespace YourMoney.Tests.Base
{
    [TestFixture]
    public class BaseServiceTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg=> cfg.AddProfile<MappingProfile>());
        }


        [TearDown]
        public void TestCleanUp() { }

        public static ApplicationDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(dbOptions);
        }
    }
}
