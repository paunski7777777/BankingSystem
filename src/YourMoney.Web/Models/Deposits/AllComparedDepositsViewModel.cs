namespace YourMoney.Web.Models.Deposits
{
    using System.Collections.Generic;

    using YourMoney.Models;

    public class AllComparedDepositsViewModel
    {
        public IEnumerable<Deposit> Deposits { get; set; }
    }
}