using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFremawork
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<Product> GetTop10Products()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.OrderByDescending(p=> p.ProductId).Take(10).ToList();
            }
        }
    }
}
