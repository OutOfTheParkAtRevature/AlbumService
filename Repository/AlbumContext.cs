using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AlbumContext : DbContext
    {
        public DbSet<Picture> Pictures { get; set; }

        public AlbumContext() { }

        public AlbumContext(DbContextOptions<AlbumContext> options) : base(options) { }
    }
}
