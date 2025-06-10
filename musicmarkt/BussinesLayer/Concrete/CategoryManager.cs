using BussinesLayer.Abstaract1;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class CategoryManager : IcategoryService
    {

        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categorydal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
           _categorydal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categorydal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }

        
    }
}
