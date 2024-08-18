using Parking.Application.Dtos;
using Parking.Application.Interfaces;
using Parking.Domain;
using Parking.Domain.Repositories;
using System.Globalization;

namespace Parking.Application.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IPricingRepository _pricingRepository;

        public ParkingService(IVehicleRepository vehicleRepository, IPricingRepository pricingRepository)
        {
            _vehicleRepository = vehicleRepository;
            _pricingRepository = pricingRepository;
        }

        public IEnumerable<VehicleStatusDto> GetAllVehicles()
        {
            var now = DateTime.Now;

            var pricing = _pricingRepository.GetPricing(now)
                ?? throw new Exception("Nenhum preço para o período atual foi encontrado!");

            var vehicles = _vehicleRepository.GetAll().ToList();

            return vehicles.Select(select => GetVehicleCompleteStatus(select, pricing, now));
        }

        public void SetNewEntry(VehicleDto vehicleDto)
        {
            var vehicle = GetVehicle(vehicleDto.Plate);

            if (vehicle != null && !vehicle.DepartureDate.HasValue)
                throw new Exception($"O veículo de placa {vehicleDto.Plate} já está estacionado!");

            vehicle = new Vehicle(vehicleDto.Plate, DateTime.Parse(vehicleDto.Date));

            _vehicleRepository.Add(vehicle);
            _vehicleRepository.Commit();
        }

        public void SetDeparture(VehicleDto vehicleDto)
        {
            var vehicle = GetVehicle(vehicleDto.Plate);

            if (vehicle == null || vehicle.DepartureDate.HasValue)
                throw new Exception($"Nenhum veículo com placa {vehicleDto.Plate} encontrado!");

            vehicle.DepartureDate = DateTime.Parse(vehicleDto.Date);

            _vehicleRepository.Update(vehicle);
            _vehicleRepository.Commit();
        }

        #region private methods

        /// <summary>
        /// Busca um veículo registrado no banco
        /// </summary>
        /// <param name="plate">Placa do veículo</param>
        /// <returns></returns>
        private Vehicle? GetVehicle(string plate)
        {
            return _vehicleRepository.GetByPlate(plate);
        }

        /// <summary>
        /// Busca e define o status completo de um veículo
        /// </summary>
        /// <param name="vehicle">Veículo registrado no banco</param>
        /// <param name="pricing">Precificação vigente</param>
        /// <param name="now">Data e hora atual</param>
        /// <returns>O veículo com seus dados e status completos</returns>
        private VehicleStatusDto GetVehicleCompleteStatus(Vehicle vehicle, Pricing pricing, DateTime now)
        {
            var duration = vehicle.GetDuration(now);
            var chargedTime = pricing.CalculateChargedTime(duration);
            var chargedValue = pricing.CalculateChargedValue(chargedTime);

            return new VehicleStatusDto()
            {
                Plate = vehicle.Plate,
                EntryDate = vehicle.EntryDate.ToString(),
                DepartureDate = vehicle.DepartureDate.HasValue ? vehicle.DepartureDate.Value.ToString() : "-",
                Duration = duration.ToString("hh:mm:ss"),
                ChargedTime = chargedTime.ToString(),
                PricingValue = FormatValue(chargedValue),
                InitialHourPricing = FormatValue(pricing.InitialHourValue),
            };
        }

        /// <summary>
        /// Formata um valor monetário para a moeda padrão
        /// </summary>
        /// <param name="value">Valor para formatação</param>
        /// <returns>O valor formatado em real</returns>
        private string FormatValue(decimal value)
        {
            return value.ToString("C", new CultureInfo("pt-BR"));
        }

        #endregion
    }
}
