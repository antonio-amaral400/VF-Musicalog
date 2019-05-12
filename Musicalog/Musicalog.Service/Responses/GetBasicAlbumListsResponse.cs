using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musicalog.Service.Responses
{
    public class GetBasicAlbumListsResponse
    {
        public Dictionary<int, string> Artists { get; set; }
        public Dictionary<int, string> Labels { get; set; }
        public Dictionary<int, string> AlbumTypes { get; set; }
    }
}