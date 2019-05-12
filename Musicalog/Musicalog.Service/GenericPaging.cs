using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace Musicalog.Service
{
    public static class GenericPaging<T>
    {
        internal static Tuple<List<T>, int> Get(List<T> aux, int limitPerPage, int pageNumber)
        {
            int totalNumberOfPages = (int)Math.Ceiling(new decimal(aux.Count) / new decimal(limitPerPage));
            return new Tuple<List<T>, int>(
                   aux
                    .Skip(limitPerPage * (pageNumber - 1))
                    .Take(limitPerPage)
                    .ToList(),
                   totalNumberOfPages);
        }
    }
}