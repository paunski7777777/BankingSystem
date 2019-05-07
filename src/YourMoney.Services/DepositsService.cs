namespace YourMoney.Services
{
    using System;

    using YourMoney.Data;
    using YourMoney.Services.Contracts;

    public class DepositsService : IDepositsService
    {
        private readonly ApplicationDbContext dbContext;

        public DepositsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}