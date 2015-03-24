using Models.Entities;
using System.Collections.Generic;

namespace Models.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
