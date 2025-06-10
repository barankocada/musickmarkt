using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstaract1
{
    public interface IArtistService
    {
        List<Artist> Getlist();
        void ArtistAdd(Artist artist);  
        void ArtistDelete(Artist artist);
        void ArtistUpdate(Artist artist);
        Artist GetByID(int id);
        Artist GetByLogin(string usn, string p);
        Artist GetByMail(string ml);

    }
}
