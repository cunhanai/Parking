namespace Parking.Domain
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

        public Vehicle(string plate, DateTime entryDate)
        {
            Plate = plate;
            EntryDate = entryDate;
        }

        /// <summary>
        /// Busca o tempo de permanência de um veículo no estacionamento.
        /// Se o veículo ainda não saiu do estacionamento, o tempo é definido com base na hora atual.
        /// </summary>
        /// <param name="now">Data e hora atual</param>
        /// <returns>O tempo total de permanência do veículo no estacionamento</returns>
        public TimeSpan GetDuration(DateTime now)
        {
            return DepartureDate.HasValue ? DepartureDate.Value.Subtract(EntryDate) : now.Subtract(EntryDate);
        }
    }
}
