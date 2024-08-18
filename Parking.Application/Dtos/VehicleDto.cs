namespace Parking.Application.Dtos
{
    /// <summary>
    /// DTO utilizado para registrar a entrada ou saída de um veículo
    /// </summary>
    public class VehicleDto
    {
        /// <summary>
        /// Placa do veículo
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Data de entrada ou saída do veículo
        /// </summary>
        public string Date { get; set; }

        public VehicleDto()
        {
        }
    }
}
