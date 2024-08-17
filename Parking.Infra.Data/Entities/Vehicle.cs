namespace Parking.Infra.Data.Entities
{
    /// <summary>
    /// Veículo que entrou no estacionamento
    /// </summary>
    public class Vehicle : EntityBase
    {
        /// <summary>
        /// Placa do veículo
        /// </summary>
        public string Plate { get; set; }

        /// <summary>
        /// Data de entrada do veículo
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Data de saída do veículo. O valor pode ser nulo caso o veículo
        /// ainda não tenha saido do estacionamento
        /// </summary>
        public DateTime? DepartureDate { get; set; }
    }
}
