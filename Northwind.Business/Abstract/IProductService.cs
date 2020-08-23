using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllList();
        List<Product> GetProductsByCategory(int selectedIndex);
        List<Product> GetProdustsByProductsName(string productName);
        List<Product> GetTop10Products();
        
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
