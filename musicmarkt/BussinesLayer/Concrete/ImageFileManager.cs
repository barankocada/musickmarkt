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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imagefiledal;

        public ImageFileManager(IImageFileDal imagefiledal)
        {
            _imagefiledal = imagefiledal;
        }

        public List<ImageFile> Getlist()
        {
            return _imagefiledal.List();
        }
    }
}
