using Models.Entities;
using System.Collections.Generic;

namespace Models.Abstract
{
    public interface IProductRepository : IRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
