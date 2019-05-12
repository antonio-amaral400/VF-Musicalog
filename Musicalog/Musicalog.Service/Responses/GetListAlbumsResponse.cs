using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicalog.Service.Responses
{
    public class GetListAlbumsResponse
    {
        public List<VAlbums> Albums { get; set; }

        public int TotalNumberOfPages { get; set; }
    }
}