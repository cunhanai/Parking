using Microsoft.AspNetCore.Mvc;
using Parking.Application.Dtos;
using Parking.Application.Interfaces;

namespace Parking.Controllers
{
    [Controller]
    [Route("pricing")]
    public class PricingController
    {
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        /// <summary>
        /// Busca todas as precificações cadastradas
        /// </summary>
        /// <returns>Uma lista com ãs informações das precificações formatadas</returns>
        [HttpGet]
        public IEnumerable<PricingDto> GetAllPricing()
        {
            return _pricingService.GetAllPricings();
        }

        /// <summary>
        /// Registra uma nova precificação para o estacionamento
        /// </summary>
        /// <param name="pricingDto">Valores e datas de vigência da precificação</param>
        [HttpPost]
        public void SetNewEntry([FromBody] PricingDto pricingDto)
        {
            _pricingService.SetNewPricing(pricingDto);
        }
    }
}
