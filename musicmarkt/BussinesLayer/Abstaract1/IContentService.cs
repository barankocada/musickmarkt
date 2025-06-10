using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstaract1
{
    public interface IContentService
    {
        List<Content> GetList(string p);   
        List<Content> GetListBySongID(int id);
        void ContentAddBL(Content content);
        Content GetByID(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        List<Content> GetListByArtist(int id);


    }
}
