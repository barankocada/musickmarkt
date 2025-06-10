using BussinesLayer.Abstaract1;
using DataAccessLayer.Abstract;
using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class AboutManager : IAboutServıce
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About about)
        {
            _aboutDal.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutDal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }

        public About GetByID(int id)
        {
            return _aboutDal.Get(x=>x.AboutID==id);
        }

        public List<About> Getlist()
        {
            return _aboutDal.List();
        }
    }
}
