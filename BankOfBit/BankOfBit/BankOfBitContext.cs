using System.Data.Entity;
using BankOfBit.Models;

namespace BankOfBit
{
    public class BankOfBitContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<BankOfBit.BankOfBitContext>());

        public BankOfBitContext() : base("name=BankOfBitContext")
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<AccountState> AccountStates { get; set; }

        public DbSet<InvestmentAccount> InvestmentAccounts { get; set; }

        public DbSet<MortgageAccount> MortgageAccounts { get; set; }

        public DbSet<ChequingAccount> ChequingAccounts { get; set; }

        public DbSet<SavingsAccount> SavingsAccounts { get; set; }
    }
}
