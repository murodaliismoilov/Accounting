using System.ComponentModel.DataAnnotations;

namespace Accounting.Shared.Models;

public class IncomeExpense:BaseEntity
{
    [Required (ErrorMessage ="Это поле обязательное к заполнению!")]
    public string? Name { get; set; }
    public CategoryIncomeExpenses? CategoryIncomeExpenses { get; set; }
    public int CategoryIncomeExpensesId { get; set; }
    public ICollection<AccountingModel>? AccountingModels { get; set; }
}
