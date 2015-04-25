using Shoppingcart.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Repositories
{
    public abstract class Repository<T, TId> : IRepository<T, TId> where T : BaseEntity<TId>, IAggregateRoot
    {
        private ShoppingcartContext dataContext;
        private readonly DbSet<T> dbset;
        protected Repository(IDataContextFactory dataContextFactory)
        {
            DataContextFactory = dataContextFactory;
            dbset = DataContext.Set<T>();
        }

        protected IDataContextFactory DataContextFactory
        {
            get;
            private set;
        }

        protected ShoppingcartContext DataContext
        {
            get { return dataContext ?? (dataContext = DataContextFactory.Get()); }
        }

        //Synchronous Code block
        public virtual void Save(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }
        public virtual T GetById(TId id)
        {
            return dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

        //Stored Procedure
        public IEnumerable<Tx> ExecWithStoreProcedure<Tx>(string query)
        {
            return DataContext.Database.SqlQuery<Tx>(query);
        }

        public void ExecuteWithStoreProcedure(string query, params object[] parameters)
        {
            DataContext.Database.ExecuteSqlCommand(query, parameters);
        }

        //Asynchronous Programming

        public virtual async Task<T> GetByIdAsync(TId id)
        {
            return await dbset.FindAsync(id);
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            return await dbset.Where(where).ToListAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await dbset.Where(where).FirstOrDefaultAsync<T>();
        }

        //Stored Procedure Async
        public async Task<IEnumerable<Tx>> ExecWithStoreProcedureAsync<Tx>(string query, params object[] parameters)
        {
            return await DataContext.Database.SqlQuery<Tx>(query, parameters).ToListAsync();
        }

        public async Task ExecuteWithStoreProcedureAsync(string query, params object[] parameters)
        {
            await DataContext.Database.ExecuteSqlCommandAsync(query, parameters);
        }

    }
}
