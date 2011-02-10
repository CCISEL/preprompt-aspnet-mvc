// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPagedList.cs" company="Centro de Cálculo do ISEL - CCISEL">
//   Luís Falcão - 2011
// </copyright>
// <summary>
//   Defines an interface for a Paged List
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyMovies.Rep.Helpers.Collections {
    using System.Collections.Generic;

    /// <summary>
    /// Defines an interface for a Paged List
    /// </summary>
    /// <typeparam name="T">The <see cref="IPagedList{T}"/> elements type</typeparam>
    public interface IPagedList<T> : IList<T> {
        int TotalCount { get; }
        int TotalPages { get; }
        int PageIndex { get; }

        int PageSize { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }
}