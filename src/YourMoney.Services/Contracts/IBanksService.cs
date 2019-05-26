namespace YourMoney.Services.Contracts
{
    using System.Linq;

    public interface IBanksService
    {
        void Add(string bankName);
        void Remove(int bankId);
        void Edit(int bankId, string bankName);
        bool ExistsById(int bankId);
        bool ExistsByName(string bankName);
        TModel GetById<TModel>(int bankId);
        IQueryable<TModel> All<TModel>();
    }
}