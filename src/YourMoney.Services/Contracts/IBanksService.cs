namespace YourMoney.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using YourMoney.Models;

    public interface IBanksService
    {
        IQueryable<TModel> All<TModel>();
        IEnumerable<Bank> AllBanks();
    }
}