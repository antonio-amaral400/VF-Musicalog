using DataAccessLayer.CachedRepository;
using DataAccessLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class RepositoryFactory
    {
        public static readonly bool ShouldUseCachedORM = ConfigurationManager.AppSettings.AllKeys.Contains("ShouldUseCachedORM") &&
                                                            Convert.ToBoolean(ConfigurationManager.AppSettings["ShouldUseCachedORM"]);

        public static GenericRepository<VAlbums> GetVAlbum()
        {
            if (ShouldUseCachedORM)
                return new VAlbumCachedRepository();
            else
                return new VAlbumRepository();
        }

        public static GenericRepository<Albums> GetAlbum()
        {
            if (ShouldUseCachedORM)
                return new AlbumCachedRepository();
            else
                return new AlbumRepository();
        }

        public static GenericRepository<Artists> GetArtist()
        {
            if (ShouldUseCachedORM)
                return new ArtistCachedRepository();
            else
                return new ArtistRepository();
        }

        public static GenericRepository<Labels> GetLabel()
        {
            if (ShouldUseCachedORM)
                return new LabelCachedRepository();
            else
                return new LabelRepository();
        }

        public static GenericRepository<AlbumType> GetAlbumType()
        {
            if (ShouldUseCachedORM)
                return new AlbumTypeCachedRepository();
            else
                return new AlbumTypeRepository();
        }
    }
}
