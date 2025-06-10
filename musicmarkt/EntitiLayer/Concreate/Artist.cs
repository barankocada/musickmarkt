using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiLayer.Concreate
{
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string ArtistSurname { get; set; }
        public string ArtistImage { get; set; }
        public string ArtistAbout { get; set; }
        public string ArtistMail { get; set; }
        public string   ArtistPassword { get; set; }
        public string ArtistTitle { get; set; }
        public bool ArtistStatus { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
