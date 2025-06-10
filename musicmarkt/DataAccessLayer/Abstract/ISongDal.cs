using DataAccessLayer.Concrete.Repositories;
using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISongDal : IRepository<Song>
    {
    }
}
