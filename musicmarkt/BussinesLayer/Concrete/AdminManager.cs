using BussinesLayer.Abstaract1;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;

        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;
        }

        public void AdminAdd(Admin admin)
        {
            _admindal.Insert(admin);
        }

        public void AdminUpdate(Admin admin)
        {
           _admindal.Update(admin);
        }

        public Admin GetAdmin(string username, string password)
        {
            return _admindal.Get(x => x.AdminUsername == username && x.AdminPassword == password);           
        }

        public Admin GetByID(int id)
        {
            return _admindal.Get(x => x.AdminID == id);
        }

        public List<Admin> Getlist()
        {
            return _admindal.List();
        }
    }
}
