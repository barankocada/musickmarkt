using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstaract1
{
    public interface IAdminService
    {
        Admin GetAdmin(string username,string password);
        List<Admin> Getlist();
        void AdminAdd(Admin admin);
        void AdminUpdate(Admin admin);
        Admin GetByID(int id);


    }
}
