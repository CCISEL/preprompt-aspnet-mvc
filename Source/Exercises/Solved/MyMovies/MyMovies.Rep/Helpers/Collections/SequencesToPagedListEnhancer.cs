using System.Collections.Generic;
using System.Linq;
using Quickipic.ServiceLayer.Helpers.Collections;

namespace MyMovies.Repository.Helpers.Collections {
    /// <summary>
    /// extension methods to create <see cref="PagedList{T}"/> given 
    /// <see cref="IEnumerable{T}"/> /> or <see cref="IQueryable{T}"/> sequences.
    /// </summary>
    public static class SequencesToPagedListEnhancer {
        private static int _DefaultPageSize = 4;

        public static void SetDefaultPageSize<T>(this IQueryable<T> source, int defaultPageSize) {
            _DefaultPageSize = defaultPageSize;
        }

        public static void SetDefaultPageSize<T>(this IEnumerable<T> source, int defaultPageSize) {
            _DefaultPageSize = defaultPageSize;
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index)
        {
            return new PagedList<T>(source, index, _DefaultPageSize);
        }


        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int total, int index, int pageSize)
        {
            return new PagedList<T>(source, total, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int total, int index)
        {
            return new PagedList<T>(source, total, index, _DefaultPageSize);
        }

        public static IPagedList<T1> Cast<T, T1>(this IPagedList<T> source)
        where T : T1 {
            IEnumerable<T> enumSource = source;
            IEnumerable<T1> enumDest = source.Cast<T1>();

            return new PagedList<T1>(enumDest, source.TotalCount, source.PageIndex, source.PageSize);
        }
    }
}