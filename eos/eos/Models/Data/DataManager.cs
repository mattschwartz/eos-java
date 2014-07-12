using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eos.Models.Data
{
    public class DataManager<T> : IDisposable where T : class
    {
        public DataContext Context = new DataContext();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T GetById(String id)
        {
            return GetById<T>(id);
        }

        public U GetById<U>(String id) where U : class
        {
            return Context.Set<U>().Find(id);
        }

        public async Task<T> GetByIdAsync(String id)
        {
            return await GetByIdAsync<T>(id);
        }

        public async Task<U> GetByIdAsync<U>(String id) where U : class
        {
            return await Context.Set<U>().FindAsync(id);
        }

        public List<T> GetAll()
        {
            return GetAll<T>();
        }

        public List<U> GetAll<U>() where U : class
        {
            var result = Context.Set<U>();

            if (result == null) {
                return null;
            }

            return result.ToList();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return Find<T>(match);
        }

        public U Find<U>(Expression<Func<U, bool>> match) where U : class
        {
            return Context.Set<U>().SingleOrDefault(match);
        }

        public List<T> FindAll(Expression<Func<T, bool>> match)
        {
            return FindAll<T>(match);
        }

        public List<U> FindAll<U>(Expression<Func<U, bool>> match) where U : class
        {
            return Context.Set<U>().Where(match).ToList();
        }

        public int Count()
        {
            return Count<T>();
        }

        public int Count<U>() where U : class
        {
            return Context.Set<U>().Count();
        }

        public DeleteResult Delete(String id)
        {
            return Delete<T>(id);
        }

        public DeleteResult Delete<U>(String id) where U : class
        {
            try {
                var entity = GetById<U>(id);

                if (entity == null) {
                    return DeleteResult.NOT_FOUND;
                }

                Context.Set<U>().Remove(entity);

                Context.SaveChanges();
            } catch (Exception ex) {
                return DeleteResult.ERROR;
            }

            return DeleteResult.SUCCESS;
        }

        public String Save(T data)
        {
            return Save<T>(data);
        }

        public String Save<U>(U data) where U : class
        {
            try {
                var dataModel = (IDataModel)data;

                var entity = (IDataModel)GetById<U>(dataModel.Id);

                if (entity == null) {
                    Context.Set<U>().Add(data);
                } else {
                    Context.Entry(entity).CurrentValues.SetValues(dataModel);
                }

                Context.SaveChanges();

                return dataModel.Id;
            } catch (Exception ex) {
                Console.WriteLine("Error in Type: {0}", typeof(U));
                return null;
            }
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