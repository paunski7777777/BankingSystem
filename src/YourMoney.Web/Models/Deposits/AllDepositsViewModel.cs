namespace YourMoney.Web.Models.Deposits
{
    using System.Collections.Generic;

    public class AllDepositsViewModel
    {
        public IEnumerable<DepositViewModel> Deposits { get; set; }
    }
}