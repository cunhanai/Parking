using Microsoft.AspNetCore.Mvc;
using Parking.Application.Dtos;
using Parking.Application.Interfaces;

namespace Parking.Controllers
{
    [Controller]
    [Route("parking")]
    public class ParkingController
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        /// <summary>
        /// Busca todos os veículos cadastrados com seus status de preço atualizados
        /// </summary>
        /// <returns>Uma lista com todos os veículos</returns>
        [HttpGet]
        public IEnumerable<VehicleStatusDto> GetAllVehicles()
        {
            return _parkingService.GetAllVehicles();
        }

        /// <summary>
        /// Registra a entrada de um veículo ao estacionamento
        /// </summary>
        /// <param name="vehicleDto">Placa e data de entrada do veículo</param>
        [HttpPost("entry")]
        public void SetNewEntry([FromBody] VehicleDto vehicleDto)
        {
            _parkingService.SetNewEntry(vehicleDto);
        }

        /// <summary>
        /// Registra a saída de um veículo ao estacionamento
        /// </summary>
        /// <param name="vehicleDto">Placa e data de saída do veículo</param>
        [HttpPost("departure")]
        public void SetDeparture([FromBody] VehicleDto vehicleDto)
        {
            _parkingService.SetDeparture(vehicleDto);
        }
    }
}
