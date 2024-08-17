using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.Infra.Data.Entities;

namespace Parking.Infra.Data.Mappings
{
    /// <summary>
    /// Mapeia a entidade <see cref="Vehicle"/> para migração do banco de dados
    /// </summary>
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable(nameof(Vehicle))
                   .HasKey(prop => prop.Id);

            builder.Property(prop => prop.Plate).IsRequired();
            builder.Property(prop => prop.EntryDate).IsRequired();
        }
    }
}
