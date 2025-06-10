using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstaract1
{
    public interface IAboutServıce
    {
        List<About> Getlist();
        void AboutAdd(About about);
        void AboutDelete(About about);
        void AboutUpdate(About about);
        About GetByID(int id);
    }
}
