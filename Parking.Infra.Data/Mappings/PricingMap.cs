using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.Infra.Data.Entities;

namespace Parking.Infra.Data.Mappings
{
    public class PricingMap : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> builder)
        {
            builder.ToTable(nameof(Pricing))
                   .HasKey(prop => prop.Id);

            builder.Property(prop => prop.InitialDate).IsRequired();
            builder.Property(prop => prop.InitialHourValue).IsRequired();
            builder.Property(prop => prop.AditionalHourValue).IsRequired();
            builder.Property(prop => prop.EndDate).IsRequired();
        }
    }
}
