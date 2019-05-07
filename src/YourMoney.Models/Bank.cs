namespace YourMoney.Models
{
    using System.Collections.Generic;

    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Deposit> Deposits { get; set; }

        public Bank()
        {
            this.Deposits = new List<Deposit>();
        }
    }
}