using Microsoft.EntityFrameworkCore;
using Parking.Domain;
using Parking.Domain.Repositories;
using Parking.Infra.Data.Context;

namespace Parking.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly ParkingContext _context;

        public Repository(ParkingContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var e = _context.Set<TEntity>().Add(entity);
            return e.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            return entity;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
