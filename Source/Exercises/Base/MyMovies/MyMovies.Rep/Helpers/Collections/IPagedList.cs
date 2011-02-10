// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPagedList.cs" company="Centro de C�lculo do ISEL - CCISEL">
//   Lu�s Falc�o - 2011
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