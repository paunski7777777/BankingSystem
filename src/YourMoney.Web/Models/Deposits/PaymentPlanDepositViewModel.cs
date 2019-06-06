namespace YourMoney.Web.Models.Deposits
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;
    using YourMoney.Models.Enums;

    public class PaymentPlanDepositViewModel
    {
        private const char PercentSymbol = '%';
        private const int OneMonthValue = 1;
        private const int ThreeMonthsValue = 3;
        private const int SixMonthsValue = 6;
        private const int NineMonthsValue = 9;
        private const int TwelveMonthsValue = 12;
        private const int TwentyFourMonthsValue = 24;
        private const int ThirtySixMonthsValue = 36;
        private const int FortyEightMonthsValue = 48;
        private const int SixtyMonthsValue = 60;
        private const int ZeroMonthsValue = 0;

        [Display(Name = GlobalConstants.DepositDetailsDislpayName)]
        public string Name { get; set; }

        [Display(Name = GlobalConstants.BankDetailsDisplayName)]
        public string BankName { get; set; }

        [Display(Name = GlobalConstants.CurrencyAddDisplayName)]
        public Currency Currency { get; set; }

        [Display(Name = GlobalConstants.EffectiveAnnualInterestRateAddDisplayName)]
        public decimal EffectiveAnnualInterestRate { get; set; }
        public string ShowEffectiveAnnualInterestRate => $"{this.EffectiveAnnualInterestRate:f2} {PercentSymbol}";

        [Display(Name = GlobalConstants.InterestPaymentPlanDisplayName)]
        public decimal Interest { get; set; }

        [Display(Name = GlobalConstants.AmountPaymentPlanDisplayName)]
        public decimal Amount { get; set; }

        [Display(Name = GlobalConstants.InterestAmountPaymentPlanDisplayName)]
        public decimal InterestAmount { get; set; }

        [Display(Name = GlobalConstants.InterestTaxAddDisplayName)]
        public decimal InterestTax { get; set; }

        [Display(Name = GlobalConstants.NetPaidAddDisplayName)]
        public decimal NetPaid { get; set; }

        public DepositTerm DepositTerm { get; set; }

        public int Months
        {
            get
            {
                if (this.DepositTerm == DepositTerm.OneMonth)
                {
                    return OneMonthValue;
                }
                if (this.DepositTerm == DepositTerm.ThreeMonths)
                {
                    return ThreeMonthsValue;
                }
                if (this.DepositTerm == DepositTerm.SixMonths)
                {
                    return SixMonthsValue;
                }
                if (this.DepositTerm == DepositTerm.NineMonths)
                {
                    return NineMonthsValue;
                }
                if (this.DepositTerm == DepositTerm.TwelveMonths)
                {
                    return TwelveMonthsValue;
                }
                if (this.DepositTerm == DepositTerm.TwentyFourMonths)
                {
                    return TwentyFourMonthsValue;
                }
                if (this.DepositTerm == DepositTerm.ThirtySixMonths)
                {
                    return ThirtySixMonthsValue;
                }
                if (this.DepositTerm == DepositTerm.FortyEightMonths)
                {
                    return FortyEightMonthsValue;
                }
                if (this.DepositTerm == DepositTerm.SixtyMonths)
                {
                    return SixtyMonthsValue;
                }
                else
                {
                    return ZeroMonthsValue;
                }
            }
        }
    }
}