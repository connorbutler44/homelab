using Homelab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homelab.Data.Configurations
{
    public class FinanceAccountConfiguration
        : IEntityTypeConfiguration<FinanceAccount>
    {
        public void Configure(EntityTypeBuilder<FinanceAccount> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasIndex(x => x.Provider)
                .IsUnique();

            builder
                .Property(x => x.Provider)
                .HasConversion<string>()
                .IsRequired();

            builder
                .Property(x => x.AccountNumberLastFour)
                .IsRequired()
                .HasMaxLength(4);
        }
    }
}