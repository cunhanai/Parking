using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Parking.Infra.Data.Context
{
    public class ParkingContextFactory : IDesignTimeDbContextFactory<ParkingContext>
    {
        public ParkingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ParkingContext>();
            optionsBuilder.UseNpgsql();

            return new ParkingContext(optionsBuilder.Options);
        }
    }
}
