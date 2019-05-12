using Musicalog.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Musicalog.Models
{
    public class AlbumListViewModel
    {
        public List<VAlbums> Albums { get; set; }

        public int CurrentPage { get; set; }

        public int TotalNumberOfPages { get; set; }

        public string OrderedBy { get; set; }


        public AlbumListViewModel(string orderedBy, int currentPage)
        {
            CurrentPage = currentPage;
            OrderedBy = orderedBy;
        }

        public void Load()
        {
            int numberOfAlbumsPerPage = 5;
            if (ConfigurationManager.AppSettings.AllKeys.Contains("NumberOfAlbumsPerPage"))
            {
                numberOfAlbumsPerPage = int.Parse(ConfigurationManager.AppSettings["NumberOfAlbumsPerPage"]);
            }

            Musicalog.Service.ServiceClient svc = new Musicalog.Service.ServiceClient();
            var response = svc.GetListAlbums(OrderedBy, CurrentPage, numberOfAlbumsPerPage);

            Albums = response.Albums.ToList();
            TotalNumberOfPages = response.TotalNumberOfPages;
        }
    }
}