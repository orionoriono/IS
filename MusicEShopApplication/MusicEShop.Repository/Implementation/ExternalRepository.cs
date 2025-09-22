using Microsoft.EntityFrameworkCore;
using MusicEShop.Domain.DomainModels;
using MusicEShop.Repository.Interface;

namespace MusicEShop.Repository.Implementation
{
    public class ExternalRepository<T> : IExternalRepository<T> where T : BaseEntity
    {
        protected readonly ExternalDbContext context;
        protected DbSet<T> entities;

        public ExternalRepository(ExternalDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        virtual public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return entities
                .ToList(); 
        }

        public T GetById(Guid? id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        IEnumerable<T> IExternalRepository<T>.GetAll()
        {
            return entities;
        }
    }
}
