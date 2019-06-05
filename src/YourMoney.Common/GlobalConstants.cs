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
        public const string FlexibleDeposit = "Гъвкав депозит";
        public const string AdvancePaymentInterestDeposit = "Депозит с авансово изплащане на лихвата";

        // Display names - Compare
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

        // Display names - Add deposit
        public const string DepositAddDisplayName = "Име на депозита";
        public const string MinimumAmountAddDisplayName = "Минимална сума";
        public const string MaximumAmountAddDisplayName = "Максимален размер на депозита";
        public const string InterestAddDisplayName = "Ефективна Годишна Лихва";
        public const string TotalPaidAddDisplayName = "Общо изплатени";
        public const string InterestAmountAddDisplayName = "Сума на лихвата";
        public const string InterestTaxAddDisplayName = "Данък върху лихвата";
        public const string NetPaidAddDisplayName = "Нетно изплатени";
        public const string DepositTypeAddDisplayName = "Тип на депозита";
        public const string ContractualInterestAddDisplayName = "Договорена лихва";
        public const string CurrencyAddDisplayName = "Валута";
        public const string DepositTermAddDisplayName = "Срок на депозита";
        public const string InterestPaymentAddDisplayName = "Изплащане на лихви";
        public const string DepositForAddDisplayName = "За кого е депозита";
        public const string InterestTypeAddDisplayName = "Вид лихва";
        public const string IncreasingAmountAddDisplayName = "Довнасяне на суми";
        public const string OverdraftOpportunityAddDisplayName = "Възможност за овърдрафт";
        public const string CreditOpportunityAddDisplayName = "Възможност за кредит";
        public const string InterestCapitalizeAddDisplayName = "Капитализира ли се лихвата в срока на депозита?";
        public const string MaximumMonthPeriodAddDisplayName = "Максимален срок(месеци)";
        public const string MinimumMonthPeriodAddDisplayName = "Минимален срок(месеци)";
        public const string ValidDepositDeadlinesAddDisplayName = "Срокове валидни за депозита (описание)";
        public const string ValidForCustomerAddDisplayName = "Валиден само за настоящи клиенти";
        public const string MonthlyAccrualAddDisplayName = "Ежемесечно олихвяване";
        public const string AdditionalTermsAddDisplayName = "Допълнителни условия";
        public const string BonusesAddDisplayName = "Бонуси";
        public const string BankAddDisplayName = "Банка";
        public const string InterestForOneMonthDisplayName = "Лихва за 1 месец";
        public const string InterestForThreeMonthsDisplayName = "Лихва за 3 месеца";
        public const string InterestForSixMonthsDisplayName = "Лихва за 6 месеца";
        public const string InterestForNineMonthsDisplayName = "Лихва за 9 месеца";
        public const string InterestForTwelveMonthsDisplayName = "Лихва за 12 месеца";
        public const string InterestForEighteenMonthsDisplayName = "Лихва за 18 месеца";
        public const string InterestForTwentyFourMonthsDisplayName = "Лихва за 24 месеца";
        public const string InterestForThirtySixMonthsDisplayName = "Лихва за 36 месеца";
        public const string InterestForFortyEightMonthsDisplayName = "Лихва за 48 месеца";
        public const string InterestForSixtyMonthsDisplayName = "Лихва за 60 месеца";

        // Areas
        public const string EmptyArea = "";

        // Controller names
        public const string DepositsControllerName = "Deposits";
        public const string BanksControllerName = "Banks";

        // Action names
        public const string ResultsActionName = "Results";
        public const string AllActionName = "All";

        // View names
        public const string ErrorViewName = "Error";

        // User roles
        public const string AdminRoleName = "Admin";
        public const string UserRoleName = "User";
        public const int UserCountCheckForAdmin = 1;

        // Banks
        public const string BankDisplayName = "Име на банка";
        public const string BankDetailsDisplayName = "Банка";

        // Deposits
        public const string DepositDisplayName = "Име на депозита";
        public const string DepositDetailsDislpayName = "Депозит";

    }
}