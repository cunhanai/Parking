using Parking.Application.Dtos;
using Parking.Application.Extensions;
using Parking.Application.Interfaces;
using Parking.Domain;
using Parking.Domain.Repositories;

namespace Parking.Application.Services
{
    public class PricingService : IPricingService
    {
        private readonly IPricingRepository _pricingRepository;

        public PricingService(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public IEnumerable<PricingDto> GetAllPricings()
        {
            var pricings = _pricingRepository.GetAll().ToList();

            return pricings.Select(select => new PricingDto
            {
                InitialHourValue = select.InitialHourValue.GetCurrency(),
                AditionalHourValue = select.AditionalHourValue.GetCurrency(),
                InitialDate = select.InitialDate.ToStringOnlyDate(),
                EndDate = select.EndDate.ToStringOnlyDate(),
                ToleranceMinutes = select.ToleranceMinutes
            });
        }

        public void SetNewPricing(PricingDto pricingDto)
        {
            var pricing = new Pricing(pricingDto.InitialDate.ToDate(),
                                      pricingDto.EndDate.ToDate(),
                                      pricingDto.InitialHourValue.GetDecimal(),
                                      pricingDto.AditionalHourValue.GetDecimal(),
                                      pricingDto.ToleranceMinutes);

            ExistsPricing(pricing);

            _pricingRepository.Add(pricing);
            _pricingRepository.Commit();
        }

        #region private methods

        /// <summary>
        /// Verifica se a data de vigência da preficação já está em uso antes de ser
        /// adicionada ao banco
        /// </summary>
        /// <param name="pricing">Precificação que está para ser adicionada ao banco</param>
        /// <exception cref="Exception">Caso a precificação já exista</exception>
        private void ExistsPricing(Pricing pricing)
        {
            if (_pricingRepository.ExistsPricingPeriod(pricing.InitialDate, pricing.EndDate))
                throw new Exception("Já existe uma precificação para esse período!");
        }

        #endregion
    }
}
