using Shoppingcart.Models;
using Shoppingcart.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Repositories
{
    public class ProductRepository:Repository<Product,int>,IProductRepository
    {
        public ProductRepository(IDataContextFactory factory)
            : base(factory) 
        {
        }
    }
}
