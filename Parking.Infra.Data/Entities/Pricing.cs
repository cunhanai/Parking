namespace Parking.Infra.Data.Entities
{
    public class Pricing : EntityBase
    {
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal InitialHourValue { get; set; }
        public decimal AditionalHourValue { get; set; }
        public TimeOnly Tolerance { get; set; }

        public Pricing(DateTime initialDate, DateTime endDate, decimal initialHourValue, decimal aditionalHourValue, TimeOnly tolerance)
        {
            InitialDate = initialDate;
            EndDate = endDate;
            InitialHourValue = initialHourValue;
            AditionalHourValue = aditionalHourValue;
            Tolerance = tolerance;
        }
    }
}
