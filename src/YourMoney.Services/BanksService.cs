﻿namespace YourMoney.Services
{
    using AutoMapper.QueryableExtensions;
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

        public IQueryable<TModel> All<TModel>()
            => this.dbContext.Banks.AsQueryable().ProjectTo<TModel>();

        public IEnumerable<Bank> AllBanks()
            => this.dbContext.Banks.ToList();
    }
}