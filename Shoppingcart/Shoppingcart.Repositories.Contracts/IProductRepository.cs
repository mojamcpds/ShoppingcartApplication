using Shoppingcart.Infrastructure.Domain;
using Shoppingcart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Repositories.Contracts
{
    public interface IProductRepository : IReadOnlyRepository<Product, int>
    {
    }
}
