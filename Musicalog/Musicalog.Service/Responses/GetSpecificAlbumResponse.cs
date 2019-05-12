using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Musicalog.Service.Responses
{
    public class GetSpecificAlbumResponse
    {
        public Albums Album { get; set; }
    }
}