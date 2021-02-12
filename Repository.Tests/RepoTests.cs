using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Model;
using System;
using System.Collections.Generic;
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
            .UseInMemoryDatabase(databaseName: "p3AlbumService")
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

        /// <summary>
        /// Tests the GetPictureById() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetPictureById()
        {
            var options = new DbContextOptionsBuilder<AlbumContext>()
            .UseInMemoryDatabase(databaseName: "p3AlbumService")
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
                var getPicture = await r.GetPictureById(picture.PictureID);
                Assert.True(getPicture.Equals(picture));
            }
        }

        /// <summary>
        /// Tests the GetPictures() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetPictures()
        {
            var options = new DbContextOptionsBuilder<AlbumContext>()
            .UseInMemoryDatabase(databaseName: "p3AlbumService")
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
                var getPictureList = await r.GetPictures();
                Assert.NotEmpty(context.Pictures);
            }
        }

        /// <summary>
        /// Tests the GetPicturesByUserId() method of Repo
        /// </summary>
        [Fact]
        public async void TestForGetPicturesByUserId()
        {
            var options = new DbContextOptionsBuilder<AlbumContext>()
            .UseInMemoryDatabase(databaseName: "p3AlbumService")
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
                var getPicture = await r.GetPicturesByUserId(picture.SubmitterID);
                var convertedList = (List<Picture>)getPicture;
                Assert.True(convertedList[0].Equals(picture));
            }
        }

        /// <summary>
        /// Tests the SortPicturesByRating() method of Repo
        /// </summary>
        [Fact]
        public async void TestForSortPicturesByRating()
        {
            var options = new DbContextOptionsBuilder<AlbumContext>()
            .UseInMemoryDatabase(databaseName: "p3AlbumService")
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

                var picture2 = new Picture
                {
                    PictureID = Guid.NewGuid(),
                    SubmitterID = "tom",
                    ImageString = "basketball",
                    ImageArray = new byte[1],
                    IsPrimary = true,
                    IsVisible = true,
                    Rating = 1
                };

                r.Pictures.Add(picture);
                r.Pictures.Add(picture2);
                await r.CommitSave();
                var getPictures = await r.SortPicturesByRating();
                var convertedList = (List<Picture>)getPictures;
                Assert.True(convertedList[0].Equals(picture2));
            }
        }
    }
}
