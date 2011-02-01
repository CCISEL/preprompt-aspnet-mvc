// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPagedList.cs" company="Servisys Solutions, Lda - Quickipic">
//   Luís Falcão - 2009
// </copyright>
// <summary>
//   Defines the IPagedList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Quickipic.ServiceLayer.Helpers.Collections
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines an interface for a Paged List
    /// </summary>
    public interface IPagedList<T>: IList<T> {
        int TotalCount { get; }
        int TotalPages { get; }
        int PageIndex { get; }

        int PageSize { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }
}