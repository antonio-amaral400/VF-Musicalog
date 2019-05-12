using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using DataAccessLayer.GenericRepository;
using System.Linq;
using DataAccessLayer.CachedRepository;
using System.Runtime.Caching;

namespace GenericProjectTests
{
    [TestClass]
    public class DAL
    {
        [TestMethod]
        public void Selects()
        {
            var albumRepo = new VAlbumRepository();
            var list = albumRepo.GetAll();
            Assert.AreEqual(3, list.ToList().Count);

            var result = albumRepo.First();
            Assert.AreEqual(1, result.Id);

            list = albumRepo.FilterByParam(a => a.Id == 1);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(1, list.ToList()[0].Id);

            list = albumRepo.GetAll().OrderByDescending(x => x.Id);
            Assert.AreEqual(3, list.ToList()[0].Id);
        }

        [TestMethod]
        public void Commands()
        {
            var albumRepo = new AlbumRepository();
            var albumTest = new Albums()
            {
                Name = "Album test",
                ArtistId = 1,
                AlbumTypeId = 1,
                LabelId = 1,
                Stock = 1
            };
            albumRepo.Insert(albumTest);
            albumRepo.Save();

            albumTest.Stock = 5;
            albumRepo.Update(albumTest);
            albumRepo.Save();
            Assert.AreEqual(5, albumRepo.First(a => a.Id == albumTest.Id).Stock);

            albumRepo.Delete(albumTest);
            albumRepo.Save();
            Assert.IsNull(albumRepo.First(a => a.Id == albumTest.Id));
        }

        [TestMethod]
        public void Cache()
        {
            var albumRepo = new AlbumCachedRepository();
            string fullNameCache = typeof(Albums).FullName;
            var cache = MemoryCache.Default;
            Assert.IsNull(cache[fullNameCache]);

            albumRepo.GetAll();
            cache = MemoryCache.Default;
            Assert.IsNotNull(cache[fullNameCache]);

            var albumTest = new Albums()
            {
                Name = "Album test",
                ArtistId = 1,
                AlbumTypeId = 1,
                LabelId = 1,
                Stock = 1
            };
            albumRepo.Insert(albumTest);
            albumRepo.Save();
            Assert.IsNull(cache[fullNameCache]);

            albumTest.Stock = 5;
            albumRepo.Update(albumTest);
            albumRepo.Save();
            Assert.IsNull(cache[fullNameCache]);
            Assert.AreEqual(5, albumRepo.First(a => a.Id == albumTest.Id).Stock);

            albumRepo.Delete(albumTest);
            albumRepo.Save();
            Assert.IsNull(cache[fullNameCache]);
            Assert.IsNull(albumRepo.First(a => a.Id == albumTest.Id));

            albumRepo.GetAll();
            Assert.IsNotNull(cache[fullNameCache]);
        }
    }
}
