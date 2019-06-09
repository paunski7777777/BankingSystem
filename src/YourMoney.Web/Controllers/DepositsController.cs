using Microsoft.AspNetCore.Authorization;

namespace YourMoney.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Linq;

    using YourMoney.Common;
    using YourMoney.Models.Enums;
    using YourMoney.Services.Contracts;
    using YourMoney.Web.Controllers.Base;
    using YourMoney.Web.Models;
    using YourMoney.Web.Models.Deposits;

    public class DepositsController : BaseController
    {
        private readonly IDepositsService depositsService;

        public DepositsController(IDepositsService depositsService)
        {
            this.depositsService = depositsService;
        }

        public IActionResult Details(int id)
        {
            var depositExists = this.depositsService.ExistsById(id);
            if (!depositExists)
            {
                var errorViewModel = new ErrorViewModel
                {
                    ErrorMessage = ErrorMessages.InvalidDepositIdMessage
                };

                return this.View(viewName: GlobalConstants.ErrorViewName, model: errorViewModel);
            }

            var depositDetailsViewModel = this.depositsService.GetById<DetailsDepositViewModel>(id);

            return this.View(depositDetailsViewModel);
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
        [Authorize]
        public IActionResult Compare(CompareDepositInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var comparedDeposits = this.depositsService
                                       .Compared<ComparedDepositViewModel>(model.Amount, model.Currency, model.DepositTerm,
                                       model.InterestPayment, model.DepositFor, model.InterestType, model.IncreasingAmount,
                                       model.OverdraftOpportunity, model.CreditOpportunity)
                                       .ToList();

            var allComparedDepositsViewModel = new AllComparedDepositsViewModel
            {
                Deposits = comparedDeposits
            };

            return this.View(viewName: GlobalConstants.ResultsActionName, allComparedDepositsViewModel);
        }

        public IActionResult Calculated(int id)
        {
            this.depositsService.CalculateDeposit(id);

            var deposit = this.depositsService.GetById<CalculatedDepositViewModel>(id);

            return this.View(deposit);
        }

        public IActionResult PaymentPlan(int id)
        {
            var paymentPlanDepositViewModel = this.depositsService.GetById<PaymentPlanDepositViewModel>(id);

            return this.View(paymentPlanDepositViewModel);
        }
    }
}