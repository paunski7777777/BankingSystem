namespace YourMoney.Models
{
    using YourMoney.Models.Enums;

    public class Deposit
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal MinimumAmount { get; set; }
        public double Interest { get; set; }

        public Currency Currency { get; set; }
        public DepositTerm DepositTerm { get; set; }
        public InterestPayment InterestPayment { get; set; }
        public DepositFor DepositFor { get; set; }
        public InterestType InterestType { get; set; }
        public IncreasingAmount IncreasingAmount { get; set; }
        public OverdraftOpportunity OverdraftOpportunity { get; set; }
        public CreditOpportunity CreditOpportunity { get; set; }

        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }

        public Deposit()
        {
            this.Currency = Currency.BGN;
            this.DepositTerm = DepositTerm.TwelveMonths;
            this.InterestPayment = InterestPayment.NoMatter;
            this.DepositFor = DepositFor.NoMatter;
            this.InterestType = InterestType.NoMatter;
            this.IncreasingAmount = IncreasingAmount.NoMatter;
            this.OverdraftOpportunity = OverdraftOpportunity.NoMatter;
            this.CreditOpportunity = CreditOpportunity.NoMatter;
        }
    }
}