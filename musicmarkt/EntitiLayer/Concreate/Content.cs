using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiLayer.Concreate
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        public bool ContentStatus { get; set; }

        public int SongID { get; set; }
        public virtual Song Song { get; set; }

        public int? ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
