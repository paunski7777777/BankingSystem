namespace YourMoney.Common
{
    public class GlobalConstants
    {
        // Common
        public const string NoMatter = "Без Значение";
        public const string Yes = "Да";
        public const string No = "Не";

        // Interest constants
        public const string Fixed = "Фиксирана";
        public const string Variable = "Променлива";

        // Term of deposit constants
        public const string OneMonth = "1 месец";
        public const string ThreeMonths = "3 месеца";
        public const string SixMonths = "6 месеца";
        public const string NineMonths = "9 месеца";
        public const string TwelveMonths = "12 месеца";
        public const string EighteenMonths = "18 месеца";
        public const string TwentyFourMonths = "24 месеца";
        public const string ThirtySixMonths = "36 месеца";
        public const string FortyEightMonths = "48 месеца";
        public const string SixtyMonths = "60 месеца";

        //For whom is the deposit constants
        public const string Individuals = "Физически лица";
        public const string Retirees = "Пенсионери";
        public const string Children = "Деца";

        // Payment of interest constants
        public const string OnMaturity = "На падеж";
        public const string InAdvance = "Авансово";
        public const string Monthly = "Ежемесечно";
        public const string EndOfPeriod = "На край на период";

        // Deposit type constants
        public const string TermDeposit = "Срочен депозит";

        // Display names
        public const decimal AmountDisplayValue = 5000;
        public const string AmountDisplayName = "РАЗМЕР НА ДЕПОЗИТА";
        public const string CurrencyDisplayName = "ВАЛУТА";
        public const string DepositTermDisplayName = "СРОК НА ДЕПОЗИТА";
        public const string InterestPaymentDisplayName = "ИЗПЛАЩАНЕ НА ЛИХВИ";
        public const string DepositForDisplayName = "ЗА КОГО Е ДЕПОЗИТА";
        public const string InterestTypeDisplayName = "ВИД ЛИХВА";
        public const string IncreasingAmountDisplayName = "ДОВНАСЯНЕ НА СУМИ";
        public const string OverdraftOpportunityDisplayName = "ВЪЗМОЖНОСТ ЗА ОВЪРДРАФТ";
        public const string CreditOpportunityDisplayName = "ВЪЗМОЖНОСТ ЗА КРЕДИТ";

        // Controller names
        public const string DepositsControllerName = "Deposits";

        // Action names
        public const string ResultsActionName = "Results";
    }
}