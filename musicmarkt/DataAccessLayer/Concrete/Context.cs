using EntitiLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contects { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ımageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
