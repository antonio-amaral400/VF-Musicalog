using DataAccessLayer;
using DataAccessLayer.CachedRepository;
using System;
using System.Linq;
using System.Collections.Generic;
using Musicalog.Service;
using Musicalog.Service.Responses;

namespace Musicalog.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public GetListAlbumsResponse GetListAlbums(string orderby, int pageNumber, int limitPerPage)
        {
            var aux = RepositoryFactory.GetVAlbum()
                                .GetAll()
                                .ToList();
            if (AlbumOrderingFactory.IsAscending(orderby))
                aux = aux
                        .OrderBy(AlbumOrderingFactory.GetFunc(orderby))
                        .ToList();
            else
                aux = aux
                        .OrderByDescending(AlbumOrderingFactory.GetFunc(orderby))
                        .ToList();

            var tempResponse = GenericPaging<VAlbums>.Get(aux, limitPerPage, pageNumber);

            return new GetListAlbumsResponse() {
                Albums = tempResponse.Item1,
                TotalNumberOfPages = tempResponse.Item2
            };
        }

        public GetBasicAlbumListsResponse GetBasicAlbumLists()
        {
            return new GetBasicAlbumListsResponse()
            {
                Artists = RepositoryFactory.GetArtist().GetAll().ToDictionary(a => a.Id, a => a.Name),
                Labels = RepositoryFactory.GetLabel().GetAll().ToDictionary(l => Convert.ToInt32(l.Id), l => l.Name),
                AlbumTypes = RepositoryFactory.GetAlbumType().GetAll().ToDictionary(at => Convert.ToInt32(at.Id), at => at.Description)
            };
        }

        public GetSpecificAlbumResponse GetSpecificAlbum(int id)
        {
            return new GetSpecificAlbumResponse() {
                Album = RepositoryFactory.GetAlbum().First(a => a.Id == id)
            };
        }

        public int InsertOrUpdate(Albums album)
        {
            var repo = RepositoryFactory.GetAlbum();
            if (album.Id > 0)
                repo.Update(album);
            else
                repo.Insert(album);

            repo.Save();

            return album.Id;
        }

        public bool Delete(int id)
        {
            var repo = RepositoryFactory.GetAlbum();
            repo.Delete(id);
            repo.Save();

            return true; // Only used to avoid problems with void Async
        }















        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
