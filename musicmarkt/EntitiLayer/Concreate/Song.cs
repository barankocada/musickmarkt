using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiLayer.Concreate
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }
        public String SongName { get; set; }
        public DateTime SongDate { get; set; }
        public bool SongStatus { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }



        public ICollection<Content> Contents { get; set; }
    }
}
