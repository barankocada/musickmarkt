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
    public class SongManager : ISongService
    {
        ISongDal _songDal;

        public SongManager (ISongDal songDal)
        {
            _songDal = songDal;
        }      
        public List<Song> GetList()
        {
            return _songDal.List(x => x.SongStatus == true);
        }

        public void SongAdd(Song song)
        {
            _songDal.Insert(song);
        }

        public void SongDelete(Song song)
        {
            _songDal.Update(song);
        }

        public void SongUpdate(Song song)
        {
           _songDal.Update(song);
        }
      
        public Song GetByID(int id)
        {
            return _songDal.Get(x => x.SongID == id);
        }

        public List<Song> GetListByArtist(int id)
        {
            return _songDal.List(x => x.ArtistID == id);
        }        
    }
}
