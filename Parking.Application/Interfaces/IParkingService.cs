using Parking.Application.Dtos;

namespace Parking.Application.Interfaces
{
    /// <summary>
    /// Responsável por gerenciar o estacionamento
    /// </summary>
    public interface IParkingService
    {
        //// <summary>
        /// Busca todos os veículos cadastrados com seus status de preço atualizados
        /// </summary>
        /// <returns>Uma lista com todos os veículos</returns>
        IEnumerable<VehicleStatusDto> GetAllVehicles();

        /// <summary>
        /// Registra a entrada de um veículo no estacionamento
        /// </summary>
        /// <param name="vehicleDto">Placa e data de entrada do veículo</param>
        /// <exception cref="Exception">Lançada caso o veículo já se encontre estacionado</exception>
        void SetNewEntry(VehicleDto vehicleDto);

        /// <summary>
        /// Registra a saída de um veículo do estacionamento
        /// </summary>
        /// <param name="vehicleDto">Placa e data de saída do veículo</param>
        /// <exception cref="Exception">Lançada caso o veículo não se encontre no estacionamento</exception>
        void SetDeparture(VehicleDto vehicleDto);
    }
}
