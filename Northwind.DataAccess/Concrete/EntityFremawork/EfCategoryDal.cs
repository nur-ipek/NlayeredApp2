using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using Northwind.Entities.Concrete.CustomEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFremawork
{
    public class EfCategoryDal: EfEntityRepositoryBase<Category,NorthwindContext>, ICategoryDal
    {
    }
}
