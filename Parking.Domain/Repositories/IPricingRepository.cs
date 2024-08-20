
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

        /// <summary>
        /// Verifica se já existe uma precificação para o período informado, seja
        /// em partes ou completo
        /// </summary>
        /// <param name="initialDate">Data inicial da vigência da precificação</param>
        /// <param name="endDate">Data inicial da vigência da precificação</param>
        /// <returns><see cref="true"/> se o período já estiver cadastrado no  banco</returns>
        bool ExistsPricingPeriod(DateTime initialDate, DateTime endDate);
    }
}
