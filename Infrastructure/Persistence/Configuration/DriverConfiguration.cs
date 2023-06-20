using Domain.Customers;
using Domain.Drivers;
using Domain.Routes;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{

    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            driversID => driversID.Value,
            value => new DriversId(value)
        );

        builder.Property(c => c.Name).HasMaxLength(50);
        builder.Property(c => c.LastName).HasMaxLength(50);
        builder.Ignore(c => c.FullName);
        builder.Property(c => c.Email).HasMaxLength(200);
        builder.HasIndex(c => c.Email).IsUnique();

        builder.Property(c => c.PhoneNumber).HasConversion(
           phoneNumber => phoneNumber.Value,
           value => PhoneNumber.Create(value)!)
           .HasMaxLength(9);

        builder.OwnsOne(c => c.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Country).HasMaxLength(3);
            addressBuilder.Property(a => a.Line1).HasMaxLength(20);
            addressBuilder.Property(a => a.Line2).HasMaxLength(20).IsRequired(false);
            addressBuilder.Property(a => a.City).HasMaxLength(40);
            addressBuilder.Property(a => a.State).HasMaxLength(40);
            addressBuilder.Property(a => a.ZipCode).HasMaxLength(10).IsRequired(false);

        });

        builder.Property(c => c.Routeid)
             .HasColumnName("RoutesId")
             .HasConversion(
                 routesId => routesId.Value,
                 value => new RoutesId(value)
             );

        builder.Property(c => c.Active).IsRequired(true);

    }
}