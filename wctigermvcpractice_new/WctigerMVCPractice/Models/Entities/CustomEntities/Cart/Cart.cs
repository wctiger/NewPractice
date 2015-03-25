using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Cart
    {
        private List<CartLine> _lineCollection = new List<CartLine>();
        
        public IEnumerable<CartLine> Lines
        {
            get { return _lineCollection; }
        }

        public void AddItem(Product product, int quantity)
        {
            CartLine line = _lineCollection.Where(c => c.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {
                _lineCollection.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            _lineCollection.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }
        public void ClearCart()
        {
            _lineCollection.Clear();
        }

        public int ComputeTotalQuantity()
        {
            return _lineCollection.Sum(c => c.Quantity);
        }

        
    }
}
