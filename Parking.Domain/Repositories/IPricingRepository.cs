
namespace Parking.Domain.Repositories
{
    /// <summary>
    /// Repositório da entidade <see cref="Pricing"/>
    /// </summary>
    public interface IPricingRepository : IRepository<Pricing>
    {
        /// <summary>
        /// Busca a precificação para a data de entrada do veículo
        /// </summary>
        /// <param name="vehicleEntryDate">Data de entrada do veículo</param>
        /// <returns></returns>
        Pricing? GetPricing(DateTime vehicleEntryDate);
    }
}
