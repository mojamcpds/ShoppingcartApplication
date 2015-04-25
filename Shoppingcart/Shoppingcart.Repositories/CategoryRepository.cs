using Shoppingcart.Models;
using Shoppingcart.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Repositories
{
    public class CategoryRepository:Repository<Category,int>,ICategoryRepository
    {
        public CategoryRepository(IDataContextFactory factory) : base(factory) 
        {
        }
    }
}
