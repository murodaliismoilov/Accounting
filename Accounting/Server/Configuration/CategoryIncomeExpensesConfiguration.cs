using Accounting.Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Server.Configuration;

public class CategoryIncomeExpensesConfiguration: BaseEntityConfiguration<CategoryIncomeExpenses>
{
    public override void Configure(EntityTypeBuilder<CategoryIncomeExpenses> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
    }
}
