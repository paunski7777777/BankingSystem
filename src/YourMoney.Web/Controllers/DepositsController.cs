namespace YourMoney.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Linq;

    using YourMoney.Common;
    using YourMoney.Models;
    using YourMoney.Models.Enums;
    using YourMoney.Services.Contracts;
    using YourMoney.Web.Controllers.Base;
    using YourMoney.Web.Models.Deposits;

    public class DepositsController : BaseController
    {
        private readonly IDepositsService depositsService;

        public DepositsController(IDepositsService depositsService)
        {
            this.depositsService = depositsService;
        }

        public IActionResult All()
        {
            var deposits = this.depositsService.All<DepositViewModel>();

            var allDepositsViewModel = new AllDepositsViewModel
            {
                Deposits = deposits
            };

            return this.View(allDepositsViewModel);
        }

        public IActionResult Compare()
        {
            var model = new CompareDepositInputModel
            {
                Amount = GlobalConstants.AmountDisplayValue,
                DepositTerm = DepositTerm.TwelveMonths
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Compare(CompareDepositInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var deposits =
                this.depositsService
                    .AllCompared<Deposit>(model.Currency, model.DepositTerm, model.InterestPayment,
                                   model.DepositFor, model.InterestType, model.IncreasingAmount,
                                   model.OverdraftOpportunity, model.CreditOpportunity)
                    .Where(d => d.Currency == model.Currency
                             && d.DepositTerm == model.DepositTerm)
                    .ToList();

            var allComparedDepositsViewModel = new AllComparedDepositsViewModel
            {
                Deposits = deposits
            };

            return this.View(viewName: GlobalConstants.ResultsActionName, allComparedDepositsViewModel);
        }
    }
}