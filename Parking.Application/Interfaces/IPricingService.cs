using Parking.Application.Dtos;

namespace Parking.Application.Interfaces
{
    /// <summary>
    /// Responsável por gerenciar a precificação do estacionamento
    /// </summary>
    public interface IPricingService
    {
        /// <summary>
        /// Busca todas as precificações cadastradas
        /// </summary>
        /// <returns>Uma lista com ãs informações das precificações formatadas</returns>
        IEnumerable<PricingDto> GetAllPricings();

        /// <summary>
        /// Registra uma nova precificação para o estacionamento
        /// </summary>
        /// <param name="pricingDto">Valores e datas de vigência da precificação</param>
        void SetNewPricing(PricingDto pricingDto);
    }
}
