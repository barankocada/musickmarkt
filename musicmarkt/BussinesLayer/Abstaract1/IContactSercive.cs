using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstaract1
{
    public interface IContactSercive
    {
        List<Contact> GetList();
        void ContactAddBL(Contact contact);
        Contact GetByID(int id);
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
