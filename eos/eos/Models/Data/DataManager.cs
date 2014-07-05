using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eos.Models.Data
{
    public class DataManager<T> : IDisposable where T : BaseModel
    {
        public DataContext Context = new DataContext();

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            if (entity == null) {
                return;
            }

            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public int Save(T data)
        {
            var entity = GetById(data.Id);

            if (entity == null) {
                Context.Set<T>().Add(data);
                entity = data;
            } else {
                Context.Entry(entity).CurrentValues.SetValues(data);
            }

            Context.SaveChanges();

            return entity.Id;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public List<T> GetAll()
        {
            var result = Context.Set<T>();

            if (result == null) {
                return null;
            }

            return result.ToList();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().SingleOrDefault(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().Where(match).ToList();
        }

        public int Count()
        {
            return Context.Set<T>().Count();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) {
                // free managed resources
                if (Context != null) {
                    Context.Dispose();
                    Context = null;
                }
            }
        }
    }
}