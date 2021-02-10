using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AlbumContext : DbContext
    {
        public DbSet<Picture> Pictures;
        public DbSet<LeagueArticle> LeagueArticles;

        public NewsContext() { }

        public NewsContext(DbContextOptions<NewsContext> options) : base(options) { }
    }
}
