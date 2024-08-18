namespace Parking.Domain
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

        /// <summary>
        /// <para>
        ///     Calcula a hora cobrada pelo tempo de um veículo no estacionamento seguindo as regras:
        /// </para>
        /// 
        /// <para>
        ///     <list type="bullet">
        ///         <item>Será cobrado metade do valor da hora inicial quando o tempo total de permanência no estacionamento for igual ou inferior a 30 minutos.</item>
        ///         <item>O valor da hora adicional possui uma tolerância de 10 minutos para cada 1 hora.</item>
        ///     </list>
        /// </para>
        /// </summary>
        /// <param name="duration">Tempo de duração de um veículo no estacionamento</param>
        /// <returns>A hora cobrada em ponto decimal</returns>
        public decimal CalculateChargedTime(TimeSpan duration)
        {
            var halfHour = 30;

            if (duration.Hours == 0 && duration.Minutes <= halfHour)
                return (decimal)0.5;

            var hour = duration.Hours;

            if (duration.Minutes > ToleranceMinutes)
                hour++;

            return hour;
        }

        /// <summary>
        /// Calcula o valor cobrado pela hora a partir do tempo cobrado.
        /// </summary>
        /// <param name="chargedTime">Hora definida pelo método <see cref="CalculateChargedTime(TimeSpan)"/></param>
        /// <returns>Retorna o valor da hora em ponto decimal</returns>
        public decimal CalculateChargedValue(decimal chargedTime)
        {
            var anHour = 1;

            if (chargedTime <= anHour)
                return chargedTime * InitialHourValue;

            return InitialHourValue + (chargedTime - anHour) * AditionalHourValue;
        }
    }
}
