namespace Parking.Application.Dtos
{
    /// <summary>
    /// DTO com o registro e o status completo do veículo
    /// </summary>
    public class VehicleStatusDto
    {
        /// <summary>
        /// Placa do veículo
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Data e hora de chegada do veículo
        /// </summary>
        public string EntryDate { get; set; }

        /// <summary>
        /// Data e hora de saída do veículo
        /// </summary>
        public string DepartureDate { get; set; }

        /// <summary>
        /// Tempo que o veículo permaneceu no estacionamento
        /// </summary>
        public string? Duration { get; set; }
        
        /// <summary>
        /// Tempo cobrado pela permanência no estacionamento em horas
        /// </summary>
        public string? ChargedTime { get; set; }

        /// <summary>
        /// Preço da hora inicial
        /// </summary>
        public string InitialHourPricing { get; set; }

        /// <summary>
        /// Valor a pagar ao estacionamento
        /// </summary>
        public string? PricingValue { get; set; }
    }
}
