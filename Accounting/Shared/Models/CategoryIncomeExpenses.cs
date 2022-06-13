using System.ComponentModel.DataAnnotations;


namespace Accounting.Shared.Models;

public class CategoryIncomeExpenses:BaseEntity
{
    [Required(ErrorMessage ="Это поле обязательное к заполнению!")]
    public string Name { get; set; }
    public ICollection<IncomeExpense>? IncomeExpenses { get; set; }
    public ICollection<AccountingModel>? AccountingModels { get; set; }
}
