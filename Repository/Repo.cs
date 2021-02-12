using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repo
    {
        private readonly AlbumContext _albumContext;
        private readonly ILogger _logger;
        public DbSet<Picture> Pictures;

        public Repo(AlbumContext albumContext, ILogger<Repo> logger)
        {
            _albumContext = albumContext;
            _logger = logger;
            this.Pictures = _albumContext.Pictures;
        }

        public async Task CommitSave()
        {
            await _albumContext.SaveChangesAsync();
        }

        public async Task<Picture> GetPictureById(Guid id)
        {
            return await Pictures.FindAsync(id);
        }

        public async Task<IEnumerable<Picture>> GetPictures()
        {
            return await Pictures.ToListAsync();
        }

        public async Task<IEnumerable<Picture>> GetPicturesByUserId(string id)
        {
            List<Picture> UserPictures = await Pictures.Where(x => x.SubmitterID == id).ToListAsync();
            return UserPictures;
        }

        public async Task<IEnumerable<Picture>> SortPicturesByRating()
        {
            List<Picture> SortedPics = await Pictures.OrderBy(x => x.Rating).ToListAsync();
            return SortedPics;
        }
    }
}
