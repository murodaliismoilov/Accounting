using Accounting.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Server.Configuration;

public class AccountingModelConfiguration: BaseEntityConfiguration<AccountingModel>
{
    public override void Configure(EntityTypeBuilder<AccountingModel> builder)
    {
        base.Configure(builder);
        builder.HasOne(x => x.IncomeExpenses).WithMany(p => p.AccountingModels).HasForeignKey(x => x.IncomeExpensesId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.CategoryIncomeExpenses).WithMany(p => p.AccountingModels).HasForeignKey(x => x.CategoryIncomeExpensesId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.Sum).IsRequired();
        builder.Property(x => x.Note).HasMaxLength(256);
    }
}
