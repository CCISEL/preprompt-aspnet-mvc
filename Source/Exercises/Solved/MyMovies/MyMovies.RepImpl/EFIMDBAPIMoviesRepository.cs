using System.Collections.Generic;

namespace MyMovies.Repository.RepositoryImplementations
{
    using System;
    using System.Linq;
    using DomainModel;
    using DomainModel.ServicesRepositoryInterfaces;
    using Quickipic.ServiceLayer.Helpers.Collections;

    public class EFIMDBAPIMoviesRepository : IMoviesRepository
    {
        private readonly MovieDBContext _moviesContext;

        public EFIMDBAPIMoviesRepository(MovieDBContext moviesContext)
        {
            _moviesContext = moviesContext;
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IRepository<Movie,int>

        /// <summary>
        /// Gets an <see cref="IQueryable{T}"/> for all Entities.
        /// </summary>
        /// <returns>An <see cref="IQueryable{TEntity}"/> for all Entities</returns>
        public IQueryable<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an <see cref="Quickipic.ServiceLayer.Helpers.Collections.IPagedList{T}"/> for the all entities.
        /// </summary>
        /// <param name="pageIndex">
        /// The required page number (0 based).
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="sortingCriteria">A coma separated list of property/field names from <see cref="TEntity"/>
        /// of the ordering being specified, followed optionally, by ascending or descending string. If empty string or <c>null</c>,
        /// the default (undetermined) sort criteria is used.
        /// <example>
        /// "Date", "Date ascending" - "Date, Kind descending".
        /// </example>
        /// </param>
        /// <returns>
        /// A <see cref="Quickipic.ServiceLayer.Helpers.Collections.IPagedList{T}"/> for all Entities
        /// </returns>
        public IPagedList<Movie> GetAll(int pageIndex, int pageSize, string sortingCriteria)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an <see cref="Quickipic.ServiceLayer.Helpers.Collections.IPagedList{T}"/> for the all entities complying with the specified <paramref name="filterCriteria"/>.
        /// </summary>
        /// <param name="filterCriteria">
        /// The filter criteria that all returned entities must fulfill.
        /// </param>
        /// <param name="pageIndex">
        /// The required page number (0 based).
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="sortingCriteria">A coma separated list of property/field names from <typeparamref name="TEntity"/>
        /// of the ordering being specified, followed optionally, by ascending or descending string. If empty string or <c>null</c>,
        /// the default (undetermined) sort criteria is used.
        /// <example>
        /// "Date", "Date ascending" - "Date, Kind descending".
        /// </example>
        /// </param>
        /// <returns>
        /// A <see cref="Quickipic.ServiceLayer.Helpers.Collections.IPagedList{T}"/> for all photographers.
        /// </returns>
        public IPagedList<Movie> GetAll(string filterCriteria, int pageIndex, int pageSize, string sortingCriteria)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an entity given the specified <paramref name="entityId"/>.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns>The <typeparamref name="TEntity"/> if it exists, <code>null</code> otherwise </returns>
        public Movie Get(int entityId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void Add(Movie entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public void Update(Movie entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        public void UpdateAll(params Movie[] entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entityId">The key of the entity to delete.</param>
        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves permanently all changes made to the repository.
        /// </summary>
        public void Save()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Refreshes the specified entities with the physical repository values overwriting the instance values.
        /// </summary>
        /// <param name="entities">The entities to refresh.</param>
        public void Refresh(params Movie[] entities)
        {
            throw new NotImplementedException();
        }

        public ICollection<Movie> SearchByTitle(string title)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}