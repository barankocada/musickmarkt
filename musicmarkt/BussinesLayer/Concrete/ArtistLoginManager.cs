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
    public class ArtistLoginManager : IArtistLoginServıce
    {
        IArtistDal _artistdal;

        public ArtistLoginManager(IArtistDal artistDal)
        {
            _artistdal = artistDal;
        }

        public Artist GetArtist(string username, string password)
        {
            return _artistdal.Get(x => x.ArtistMail == username && x.ArtistPassword == password);
        }
    }
}
