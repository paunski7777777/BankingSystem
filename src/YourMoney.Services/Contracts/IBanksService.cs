namespace YourMoney.Services.Contracts
{
    using System.Linq;

    public interface IBanksService
    {
        IQueryable<TModel> All<TModel>();
    }
}