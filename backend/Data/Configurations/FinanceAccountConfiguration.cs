using Homelab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FinanceAccountConfiguration
    : IEntityTypeConfiguration<FinanceAccount>
{
    public void Configure(EntityTypeBuilder<FinanceAccount> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Key)
            .IsUnique();

        builder
            .Property(x => x.Key)
            .IsRequired();

        builder
            .Property(x => x.AccountNumberLastFour)
            .IsRequired()
            .HasMaxLength(4);
    }
}