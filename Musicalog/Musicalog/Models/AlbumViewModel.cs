using Musicalog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicalog.Models
{
    public class AlbumViewModel
    {
        public Albums Album { get; set; }

        public Operation OperationType { get; set; }

        public Dictionary<int, string> Artists { get; set; }
        public Dictionary<int, string> Labels { get; set; }
        public Dictionary<int, string> AlbumTypes { get; set; }

        public AlbumViewModel()
        {

        }
        
        public AlbumViewModel(int? id)
        {
            if (id.HasValue)
            {
                Album = new Albums() { Id = id.Value };
                OperationType = Operation.UPDATE;
            }
            else
            {
                OperationType = Operation.CREATE;
            }
        }

        public void Prepare()
        {
            Musicalog.Service.ServiceClient svc = new Musicalog.Service.ServiceClient();
            var response = svc.GetBasicAlbumLists();
            Artists = response.Artists;
            Labels = response.Labels;
            AlbumTypes = response.AlbumTypes;

            if (OperationType == Operation.UPDATE)
            {
                Album = svc.GetSpecificAlbum(Album.Id).Album;
            }
            else
            {
                Album = new Albums() { Id = 0 };
            }
        }

        internal void Save()
        {
            Musicalog.Service.ServiceClient svc = new Musicalog.Service.ServiceClient();
            svc.InsertOrUpdate(Album);
        }

        public enum Operation
        {
            CREATE,
            UPDATE
        }

    }
}