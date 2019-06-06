namespace YourMoney.Web.Models.Deposits
{
    using System.ComponentModel.DataAnnotations;

    using YourMoney.Common;

    public class CalculatedDepositViewModel : DetailsDepositViewModel
    {
        private const char PercentSymbol = '%';
        private const string BGNcurrencyDisplayName = "BGN";
        private const string CHFcurrencyDisplayName = "CHF";
        private const string EURcurrencyDisplayName = "EUR";
        private const string GBPcurrencyDisplayName = "GBP";
        private const string USDcurrencyDisplayName = "USD";

        [Display(Name = GlobalConstants.EffectiveAnnualInterestRateAddDisplayName)]
        public decimal EffectiveAnnualInterestRate { get; set; }
        public string ShowEffectiveAnnualInterestRate => $"{this.EffectiveAnnualInterestRate:f2} {PercentSymbol}";

        [Display(Name = GlobalConstants.TotalPaidAddDisplayName)]
        public decimal TotalPaid { get; set; }
        public string ShowTotalPaid => $"{this.TotalPaid:f2} {this.ShowCurrency}";

        [Display(Name = GlobalConstants.InterestAmountAddDisplayName)]
        public decimal InterestAmount { get; set; }
        public string ShowInterestAmount => $"{this.InterestAmount:f2} {this.ShowCurrency}";

        [Display(Name = GlobalConstants.InterestTaxAddDisplayName)]
        public decimal InterestTax { get; set; }
        public string ShowInterestTax => $"{this.InterestTax:f2} {this.ShowCurrency}";

        [Display(Name = GlobalConstants.NetPaidAddDisplayName)]
        public decimal NetPaid { get; set; }
        public string ShowNetPaid => $"{this.NetPaid:f2} {this.ShowCurrency}";

        public string ShowCurrency
        {
            get
            {
                if (this.Currency == YourMoney.Models.Enums.Currency.BGN)
                {
                    return BGNcurrencyDisplayName;
                }
                if (this.Currency == YourMoney.Models.Enums.Currency.CHF)
                {
                    return CHFcurrencyDisplayName;
                }
                if (this.Currency == YourMoney.Models.Enums.Currency.EUR)
                {
                    return EURcurrencyDisplayName;
                }
                if (this.Currency == YourMoney.Models.Enums.Currency.GBP)
                {
                    return GBPcurrencyDisplayName;
                }
                if (this.Currency == YourMoney.Models.Enums.Currency.USD)
                {
                    return USDcurrencyDisplayName;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}