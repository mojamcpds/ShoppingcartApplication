using Shoppingcart.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Repositories
{
    public class DataContextFactory : IDataContextFactory
    {
        private ShoppingcartContext dataContext;
        public ShoppingcartContext Get()
        {
            return dataContext ?? (dataContext = new ShoppingcartContext());
        }


        #region IDisposable implement

        private bool isDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (dataContext != null)
                {
                    dataContext.Dispose();
                }

                isDisposed = true;
            }

        }
        #endregion

    }
}
