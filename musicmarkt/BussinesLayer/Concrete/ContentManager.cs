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
    public class ContentManager : IContentService
    {
        IContentDal _contentdal;

        public ContentManager(IContentDal contentdal)
        {
            _contentdal = contentdal;
        }

        public void ContentAddBL(Content content)
        {
            _contentdal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string p)
        {
            return _contentdal.List();
        }

        public List<Content> GetListByArtist(int id)
        {
            return _contentdal.List(x => x.ArtistID == id);
        }

        public List<Content> GetListBySongID(int id)
        {
            return _contentdal.List(x => x.SongID == id);
        }
    }
}
