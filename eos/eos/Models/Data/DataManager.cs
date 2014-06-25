using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using eos.Models.Data;

namespace Aztec.Data.Data
{
    public class DataManager<T> : IDisposable where T : BaseModel
    {
        public DataContext Context = new DataContext();

        public T GetById(int id)
        {
            return this.Context.Set<T>().Find(id);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            if (entity == null) {
                return;
            }

            this.Context.Set<T>().Remove(entity);
            this.Context.SaveChanges();
        }

        public int Save(T data)
        {
            var entity = GetById(data.Id);

            if (entity == null) {
                this.Context.Set<T>().Add(data);
                entity = data;
            } else {
                this.Context.Entry(entity).CurrentValues.SetValues(data);
            }

            this.Context.SaveChanges();

            return entity.Id;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.Context.Set<T>().FindAsync(id);
        }

        public List<T> GetAll()
        {
            var result = this.Context.Set<T>();

            if (result == null) {
                return null;
            }

            return result.ToList();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return this.Context.Set<T>().SingleOrDefault(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return this.Context.Set<T>().Where(match).ToList();
        }

        public int Count()
        {
            return this.Context.Set<T>().Count();
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
                if (this.Context != null) {
                    this.Context.Dispose();
                    this.Context = null;
                }
            }
        }
    }
}