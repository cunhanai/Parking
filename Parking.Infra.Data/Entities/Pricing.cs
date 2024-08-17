namespace Parking.Infra.Data.Entities
{
    /// <summary>
    /// Valor praticado pelo estacionamento
    /// </summary>
    public class Pricing : EntityBase
    {
        /// <summary>
        /// Valor da hora inicial de permanência do veículo
        /// </summary>
        public decimal InitialHourValue { get; set; }

        /// <summary>
        /// Valor da hora adicional de permanência do veículo
        /// </summary>
        public decimal AditionalHourValue { get; set; }

        /// <summary>
        /// Minutos de tolerância da hora adicional, aplicado caso o tempo de permanência do veículo
        /// seja superior ao da <see cref="InitialHourValue">hora incial</see> e estiver dentro da tolerância,
        /// não haverá cobrança adicional no valor
        /// definido 
        /// </summary>
        public int ToleranceMinutes { get; set; }

        /// <summary>
        /// Data de início da vigência do valor
        /// </summary>
        public DateTime InitialDate { get; set; }

        /// <summary>
        /// Data final da vigência do valor
        /// </summary>
        public DateTime EndDate { get; set; }

        public Pricing(DateTime initialDate, DateTime endDate, decimal initialHourValue, decimal aditionalHourValue, int toleranceMinutes)
        {
            InitialDate = initialDate;
            EndDate = endDate;
            InitialHourValue = initialHourValue;
            AditionalHourValue = aditionalHourValue;
            ToleranceMinutes = toleranceMinutes;
        }

        public Pricing(int id, DateTime initialDate, DateTime endDate, decimal initialHourValue, decimal aditionalHourValue, int toleranceMinutes)
        {
            Id = id;
            InitialDate = initialDate;
            EndDate = endDate;
            InitialHourValue = initialHourValue;
            AditionalHourValue = aditionalHourValue;
            ToleranceMinutes = toleranceMinutes;
        }
    }
}
