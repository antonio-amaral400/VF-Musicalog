using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace Musicalog.Service
{
    public static class AlbumOrderingFactory
    {
        private static Dictionary<string, Func<VAlbums, object>> Factory;

        private static void InitializeIfNecessary()
        {
            if (Factory == null)
            {
                Factory = new Dictionary<string, Func<VAlbums, object>>();
                Factory["id"] = va => va.Id;
                Factory["name"] = va => va.Name.ToLower();
                Factory["artist"] = va => va.Artist.ToLower();
                Factory["label"] = va => va.Label.ToLower();
                Factory["type"] = va => va.AlbumType.ToLower();
                Factory["stock"] = va => va.Stock;
            }
        }


        internal static Func<VAlbums, object> GetFunc(string orderby)
        {
            InitializeIfNecessary();
            return Factory[orderby.ToLower().Split('-')[0]];
        }

        internal static bool IsAscending(string orderby)
        {
            return orderby.ToLower().Split('-')[1] == "a";
        }
    }
}