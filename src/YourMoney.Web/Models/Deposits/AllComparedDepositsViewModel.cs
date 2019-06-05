namespace YourMoney.Web.Models.Deposits
{
    using System.Collections.Generic;

    public class AllComparedDepositsViewModel
    {
        public IEnumerable<ComparedDepositViewModel> Deposits { get; set; }
    }
}