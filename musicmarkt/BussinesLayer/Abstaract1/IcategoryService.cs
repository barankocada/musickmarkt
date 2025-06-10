using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstaract1
{
    public interface IcategoryService
    {
        List<Category> GetList(); 
        void CategoryAddBL(Category category);
        Category GetByID(int id);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
    }
}
