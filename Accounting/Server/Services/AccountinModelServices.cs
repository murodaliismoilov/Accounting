using Accounting.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Server;

public interface IAccountingModelService : IGenericRepository<AccountingModel>
{
    Task<IList<AccountingModel>> GetIncomesAsync();
    Task<IList<AccountingModel>> GetExpensesAsync();
    Task<IList<AccountingModel>> GetAllAccountingAsync();
}
public class AccountingModelService : GrudOperations<AccountingModel>, IAccountingModelService
{
    public AccountingModelService(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IList<AccountingModel>> GetIncomesAsync()
    {
        return await Context.Accountings
            .Where(x => x.CategoryIncomeExpensesId == 1).ToListAsync();
    }

    public async Task<IList<AccountingModel>> GetExpensesAsync()
    {
        return await Context.Accountings
            .Where(x => x.CategoryIncomeExpensesId == 2).ToListAsync();
    }

    public async Task<IList<AccountingModel>> GetAllAccountingAsync()
    {
        return await Context.Accountings
            .Include(x => x.CategoryIncomeExpenses)
            .ToListAsync();
    }
}
