using Microsoft.EntityFrameworkCore;
using Accounting.Server.Configuration;
using Accounting.Shared.Models;

namespace Accounting.Server;

public class ApplicationDbContext : DbContext
{
    public DbSet<AccountingModel> Accountings { get; set; }
    public DbSet<IncomeExpense> IncomeExpense { get; set; }
    public DbSet<CategoryIncomeExpenses> CategoryIncomeExpense { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountingModelConfiguration());
        modelBuilder.ApplyConfiguration(new IncomeExpensesConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryIncomeExpensesConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
