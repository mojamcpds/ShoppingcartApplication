using Shoppingcart.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContextFactory databaseFactory;
        private ShoppingcartContext dataContext;

        public UnitOfWork(IDataContextFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected ShoppingcartContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public int Commit()
        {
            return DataContext.Commit();
        }

        public async Task<int> CommitAsync()
        {
            return await DataContext.CommitAsync();
        }
    }
}
