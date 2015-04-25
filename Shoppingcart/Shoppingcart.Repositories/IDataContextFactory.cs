using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Repositories
{
    public interface IDataContextFactory : IDisposable
    {
        ShoppingcartContext Get();
    }
}
