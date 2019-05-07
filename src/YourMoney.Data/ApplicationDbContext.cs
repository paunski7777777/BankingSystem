namespace YourMoney.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using YourMoney.Models;

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Deposit> Deposits { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
    }
}
