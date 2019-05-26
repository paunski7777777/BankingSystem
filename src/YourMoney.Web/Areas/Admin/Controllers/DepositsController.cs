namespace YourMoney.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Linq;

    using YourMoney.Common;
    using YourMoney.Services.Contracts;
    using YourMoney.Web.Areas.Admin.Controllers.Base;
    using YourMoney.Web.Areas.Admin.Models.Deposits;
    using YourMoney.Web.Models;

    public class DepositsController : AdminBaseController
    {
        private readonly IDepositsService depositsService;
        private readonly IBanksService banksService;

        public DepositsController(IDepositsService depositsService, IBanksService banksService)
        {
            this.depositsService = depositsService;
            this.banksService = banksService;
        }

        public IActionResult Add()
        {
            var banks = this.banksService.All<SelectListItem>().ToList();

            var addDepositInputModel = new AddDepositInputModel
            {
                Banks = banks
            };

            return this.View(addDepositInputModel);
        }

        [HttpPost]
        public IActionResult Add(AddDepositInputModel model)
        {
            var banks = this.banksService.All<SelectListItem>().ToList();

            if (!this.ModelState.IsValid)
            {
                model.Banks = banks;

                return this.View(model);
            }

            var depositExists = this.depositsService.ExistsByName(model.Name);
            if (depositExists)
            {
                var errorViewModel = new ErrorViewModel
                {
                    ErrorMessage = string.Format(ErrorMessages.DepositAlreadyExitstMessage, model.Name)
                };

                return this.View(viewName: GlobalConstants.ErrorViewName, model: errorViewModel);
            }

            this.depositsService.Add(model.Name, model.MinimumAmount, model.MaximumAmount, model.Interest,
                model.TotalPaid, model.InterestAmount, model.InterestTax, model.NetPaid, model.DepositType,
                model.ContractualInterest, model.Currency, model.DepositTerm, model.InterestPayment, model.DepositFor,
                model.InterestType, model.IncreasingAmount, model.OverdraftOpportunity, model.CreditOpportunity,
                model.InterestCapitalize, model.MaximumMonthPeriod, model.MinimumMonthPeriod, model.ValidDepositDeadlines,
                model.ValidForCustomer, model.MonthlyAccrual, model.AdditionalTerms, model.Bonuses, model.BankId);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
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

            var bank = this.depositsService.GetById<DepositViewModel>(id);

            return this.View(bank);
        }

        [HttpPost]
        public IActionResult Delete(DepositViewModel model)
        {
            this.depositsService.Remove(model.Id);

            return this.RedirectToAction(nameof(All));
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
    }
}