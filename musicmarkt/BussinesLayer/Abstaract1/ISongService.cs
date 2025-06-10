using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstaract1
{
    public interface ISongService
    {
        List<Song> GetList();
        List<Song> GetListByArtist(int id);
        void SongAdd(Song song);
        Song GetByID(int id);      
        void SongDelete(Song song);
        void SongUpdate(Song song);

    }
}
