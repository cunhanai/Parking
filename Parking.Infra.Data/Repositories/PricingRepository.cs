using Parking.Domain;
using Parking.Domain.Repositories;
using Parking.Infra.Data.Context;

namespace Parking.Infra.Data.Repositories
{
    public class PricingRepository : Repository<Pricing>, IPricingRepository
    {
        public PricingRepository(ParkingContext context) : base(context)
        {
        }

        public Pricing? GetPricing(DateTime date)
        {
            return GetAll().FirstOrDefault(first => date >= first.InitialDate && date <= first.EndDate);
        }

        public bool ExistsPricingPeriod(DateTime initialDate, DateTime endDate)
        {
            return GetAll().Any(any => (initialDate >= any.InitialDate && initialDate <= any.EndDate) ||
                                       (endDate >= any.InitialDate && initialDate <= any.EndDate));
        }
    }
}
