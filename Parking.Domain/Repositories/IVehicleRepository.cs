namespace Parking.Domain.Repositories
{
    /// <summary>
    /// Repositório da entidade <see cref="Vehicle"/>
    /// </summary>
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        /// <summary>
        /// Busca um veículo pela sua placa
        /// </summary>
        /// <param name="plate">Placa do veículo</param>
        /// <returns></returns>
        Vehicle? GetByPlate(string plate);
    }
}
