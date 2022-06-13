using System.ComponentModel.DataAnnotations;
namespace Accounting.Shared.Models;

public class AccountingModel:BaseEntity
{
    public DateTime AddedDate { get; set; } = DateTime.Now;
    public IncomeExpense? IncomeExpenses { get; set; }
    [Range(1, 100000000000000, ErrorMessage = "Это поле обязательно к заполнению!")]    
    public int IncomeExpensesId { get; set; }
    public CategoryIncomeExpenses? CategoryIncomeExpenses { get; set; }
    [Range(1, 100000000000000, ErrorMessage = "Это поле обязательно к заполнению!")]
    public int CategoryIncomeExpensesId { get; set; }
    public string? Note { get; set; }
    [Range(1, 1.7976931348623157E+308, ErrorMessage = "Это поле обязательно к заполнению!")]
    public double Sum { get; set; }
}

