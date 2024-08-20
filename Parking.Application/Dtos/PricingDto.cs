namespace Parking.Application.Dtos
{
    /// <summary>
    /// DTO com o registro completo de uma precificação
    /// </summary>
    public class PricingDto
    {
        /// <summary>
        /// Valor da hora inicial de permanência do veículo formatado
        /// </summary>
        public string InitialHourValue { get; set; }

        /// <summary>
        /// Valor da hora adicional de permanência do veículo formatado
        /// </summary>
        public string AditionalHourValue { get; set; }

        /// <summary>
        /// Minutos de tolerância da hora adicional
        /// </summary>
        public int ToleranceMinutes { get; set; }

        /// <summary>
        /// Data de início da vigência do valor formatado
        /// </summary>
        public string InitialDate { get; set; }

        /// <summary>
        /// Data final da vigência do valor formatado
        /// </summary>
        public string EndDate { get; set; }
    }
}
