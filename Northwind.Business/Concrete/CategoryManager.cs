using Northwind.Business.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
   public class CategoryManager: ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal productDal)
        {
            _categoryDal = productDal;
        }

        public List<Category> GetAllList()
        {
            return _categoryDal.GetAll();
        }
    }
}
