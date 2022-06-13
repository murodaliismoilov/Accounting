using Accounting.Shared.Models;

namespace Accounting.Server.Services
{
    public interface ICategoryIncomeExpensesService : IGenericRepository<CategoryIncomeExpenses>
    {

    }
    public class CategoryIncomeExpensesService : GrudOperations<CategoryIncomeExpenses>, ICategoryIncomeExpensesService
    {
        public CategoryIncomeExpensesService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
