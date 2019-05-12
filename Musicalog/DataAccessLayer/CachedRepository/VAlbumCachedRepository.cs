using DataAccessLayer.CachedRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CachedRepository
{
    public class VAlbumCachedRepository : CachedRepository<VAlbums>
    {
        public override void Save()
        {
            base.Save();

            var cache = MemoryCache.Default;
            cache.Remove(new AlbumCachedRepository().GetClassName());
        }
    }
}
