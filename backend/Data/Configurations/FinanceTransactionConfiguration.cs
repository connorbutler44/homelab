using Homelab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Configurations
{
    public class FinanceTransactionConfiguration
        : IEntityTypeConfiguration<FinanceTransaction>
    {
        public void Configure(EntityTypeBuilder<FinanceTransaction> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.FinanceAccount)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.FinanceAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}