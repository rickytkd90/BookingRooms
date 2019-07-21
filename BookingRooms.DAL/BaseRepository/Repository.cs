using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal BookingRoomsEntities dbContext;
        internal DbSet<TEntity> dbSet;

        public Repository(BookingRoomsEntities dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            TEntity entity = dbSet.Find(id);
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public TEntity InsertAndGet(TEntity entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
