using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FastDeliveryAPI.Entity;

namespace FastDeliveryAPI.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .HasMaxLength(100)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(b => b.PhoneNumber)
            .HasMaxLength(9)
            .HasColumnType("text")
            .HasColumnName("PhoneNumberCustomer");

        builder.Property(b => b.Email)
            .HasMaxLength(120)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(b => b.Address)
            .HasColumnType("text")
            .IsRequired()
            .HasMaxLength(120);

    }
}