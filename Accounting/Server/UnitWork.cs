using Accounting.Server.Services;

namespace Accounting.Server;

public interface IUnitOfWork
{
    public IAccountingModelService AccountingModelService { get;}
    public IIncomeExpensesService IncomeExpensesService { get;}
    public ICategoryIncomeExpensesService CategoryIncomeExpensesService { get;}

}

public class AccountingUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public AccountingModelService accountingModelService;
    public IncomeExpensesService incomeExpensesService;
    public CategoryIncomeExpensesService categoryIncomeExpensesService;
    public AccountingUnitOfWork(ApplicationDbContext context)
    {
        this._context = context;
    }
    public IAccountingModelService AccountingModelService => accountingModelService = accountingModelService ?? new AccountingModelService(_context);
    public IIncomeExpensesService IncomeExpensesService => incomeExpensesService = incomeExpensesService ?? new IncomeExpensesService(_context);
    public ICategoryIncomeExpensesService CategoryIncomeExpensesService => categoryIncomeExpensesService = categoryIncomeExpensesService ?? new CategoryIncomeExpensesService(_context);
}
