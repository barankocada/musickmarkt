using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiLayer.Concreate
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime ContactDate { get; set; }

        public int ContentID { get; set; }
        public virtual Content Content { get; set; }
    }
}
