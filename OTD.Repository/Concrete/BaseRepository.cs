using Microsoft.EntityFrameworkCore;
using OTD.Repository.Abstract;
using System.Linq.Expressions;

namespace OTD.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            var activeEntity = _dbSet.Add(entity);
            activeEntity.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var activeEntity = _context.Entry(entity);
            activeEntity.State = EntityState.Deleted;
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(condition);
        }

        public List<T> GetList(Expression<Func<T, bool>> condition = null)
        {
            var list = condition == null ?
                _context.Set<T>().ToList() :
                _context.Set<T>().Where(condition).ToList();

            return list;
        }

        public void Update(T entity)
        {
            var activeEntity = _context.Entry(entity);
            activeEntity.State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
