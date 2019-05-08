namespace YourMoney.Web.Models.Banks
{
    using System.Collections.Generic;

    using YourMoney.Web.Models.Deposits;

    public class BankViewModel
    {
        public string Name { get; set; }
        public IEnumerable<BankDepositViewModel> Deposits { get; set; }
    }
}