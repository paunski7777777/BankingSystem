namespace YourMoney.Services
{
    using AutoMapper.QueryableExtensions;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using YourMoney.Data;
    using YourMoney.Models;
    using YourMoney.Services.Contracts;

    public class BanksService : IBanksService
    {
        private readonly ApplicationDbContext dbContext;

        public BanksService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(string bankName)
        {
            var bank = new Bank
            {
                Name = bankName
            };

            this.dbContext.Banks.Add(bank);
            this.dbContext.SaveChanges();
        }

        public void Edit(int bankId, string bankName)
        {
            var bank = this.dbContext.Banks.FirstOrDefault(b => b.Id == bankId);

            bank.Name = bankName;

            this.dbContext.Update(bank);
            this.dbContext.SaveChanges();
        }

        public void Remove(int bankId)
        {
            var bank = this.dbContext.Banks.FirstOrDefault(b => b.Id == bankId);

            this.dbContext.Banks.Remove(bank);
            this.dbContext.SaveChanges();
        }

        public bool ExistsById(int bankId)
            => this.dbContext.Banks.Any(b => b.Id == bankId);

        public bool ExistsByName(string bankName)
            => this.dbContext.Banks.Any(b => b.Name == bankName);

        public TModel GetById<TModel>(int bankId)
            => this.By<TModel>(t => t.Id == bankId).SingleOrDefault();

        public IQueryable<TModel> All<TModel>()
           => this.dbContext.Banks.AsQueryable().ProjectTo<TModel>();

        private IEnumerable<TModel> By<TModel>(Func<Bank, bool> predicate)
          => this.dbContext.Banks.Where(predicate).AsQueryable().ProjectTo<TModel>();
    }
}