using Domain.Customers;
using Domain.Drivers;
using Domain.Routes;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{

    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            routesId => routesId.Value,
            value => new RoutesId(value)
        );

        builder.Property(c => c.Origin).HasMaxLength(50);
        builder.Property(c => c.Destination).HasMaxLength(50);

        builder.Property(c => c.Distance).HasMaxLength(200);

        builder.Property(c => c.Active).IsRequired(true);

    }
}