using Accounting.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Server.Configuration;

public class IncomeExpensesConfiguration : BaseEntityConfiguration<IncomeExpense>
{
    public override void Configure(EntityTypeBuilder<IncomeExpense> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
    }
}
