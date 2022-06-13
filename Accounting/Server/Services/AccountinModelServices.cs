using Accounting.Shared.Models;

namespace Accounting.Server;

public interface IAccountingModelService : IGenericRepository<AccountingModel>
{
   
}
public class AccountingModelService : GrudOperations<AccountingModel>, IAccountingModelService
{
    public AccountingModelService(ApplicationDbContext context) : base(context)
    {
    }
}
