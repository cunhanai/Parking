using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.Infra.Data.Entities;
using Parking.Infra.Data.Entities.Data;

namespace Parking.Infra.Data.Mappings
{
    /// <summary>
    /// Mapeia a entidade <see cref="Pricing"/> para migração do banco de dados
    /// </summary>
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

            builder.HasData(DefaultData.GetDefaultPricing());
        }
    }
}
