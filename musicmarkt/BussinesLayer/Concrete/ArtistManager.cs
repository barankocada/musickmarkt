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
    public class ArtistManager : IArtistService
    {
        IArtistDal _artistDal;

        public ArtistManager(IArtistDal artistDal)
        {
            _artistDal = artistDal;
        }

        public void ArtistAdd(Artist artist)
        {
            _artistDal.Insert(artist);
        }

        public void ArtistDelete(Artist artist)
        {
            _artistDal.Delete(artist);
        }

        public void ArtistUpdate(Artist artist)
        {
            _artistDal.Update(artist);
        }

        public Artist GetByID(int id)
        {
            return _artistDal.Get(x => x.ArtistID == id);
        }

        public Artist GetByLogin(string usn, string p)
        {
            var userartistınfo = _artistDal.Get(x => x.ArtistMail == usn && x.ArtistPassword == p);
            return userartistınfo;
        }

        public Artist GetByMail(string ml)
        {
            return _artistDal.Get(x => x.ArtistMail == ml);
        }

        public List<Artist> Getlist()
        {
            return _artistDal.List();
        }
    }
}
