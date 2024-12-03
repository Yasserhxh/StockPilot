using Microsoft.EntityFrameworkCore;
using StockPilot.Domain.IRepositories;
using StockPilot.Infrastructure.Data;

namespace StockPilot.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        protected DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
        }

        public List<T> GetAll()=> _dbSet.ToList();

        public T GetById(int id) => _dbSet.Find(id);

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges() ;
        }
    }
}
