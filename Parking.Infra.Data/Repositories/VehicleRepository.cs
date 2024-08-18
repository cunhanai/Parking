using Parking.Domain;
using Parking.Domain.Repositories;
using Parking.Infra.Data.Context;

namespace Parking.Infra.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ParkingContext context) : base(context)
        {
        }

        public Vehicle? GetByPlate(string plate)
        {
            return GetAll().FirstOrDefault(where => where.Plate == plate);
        }
    }
}
