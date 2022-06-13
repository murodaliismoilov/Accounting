
using Accounting.Shared.Models;

namespace Accounting.Server.Services;

public interface IIncomeExpensesService : IGenericRepository<IncomeExpense>
{

}
public class IncomeExpensesService : GrudOperations<IncomeExpense>, IIncomeExpensesService
{
    public IncomeExpensesService(ApplicationDbContext context) : base(context)
    {
    }
}
