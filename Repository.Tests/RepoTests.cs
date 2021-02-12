using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Model;
using System;
using Xunit;

namespace Repository.Tests
{
    public class RepoTests
    {
        /// <summary>
        /// Tests the CommitSave() method of Repo
        /// </summary>
        [Fact]
        public async void TestForCommitSave()
        {
            var options = new DbContextOptionsBuilder<AlbumContext>()
            .UseInMemoryDatabase(databaseName: "p3NewsService")
            .Options;

            using (var context = new AlbumContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Repo r = new Repo(context, new NullLogger<Repo>());
                var picture = new Picture
                {
                    PictureID = Guid.NewGuid(),
                    SubmitterID = "tom",
                    ImageString = "basketball",
                    ImageArray = new byte[1],
                    IsPrimary = true,
                    IsVisible = true,
                    Rating = 3
                };

                r.Pictures.Add(picture);
                await r.CommitSave();
                Assert.NotEmpty(context.Pictures);
            }
        }
    }
}
