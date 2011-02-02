// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EFDbContextRepository.cs" company="Centro de Cálculo do ISEL - CCISEL">
//   Luís Falcão - 2011
// </copyright>
// <summary>
//   LinqToSql implementation of
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using MyMovies.Rep.Helpers.Collections;

namespace MyMovies.Rep {
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// EntityFramework implementation of <see cref="IRepository{TSLEntity,TSLKey}"/>
    /// </summary>
    /// <typeparam name="TEntity">The TSLEntity type</typeparam>
    /// <typeparam name="TKey">The type of the TSLEntity key.</typeparam>
    public class EFDbContextRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        /// <summary>
        /// The <see cref="DbContext"/> derived type instance
        /// </summary>
        private readonly DbContext _dbContext;

        /// <summary>
        /// The <see cref="DbSet{TSLEntity}"/> corresponding to the entity represented by the Repository.
        /// </summary>
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// The Key selector expression for instances of <typeparamref name="TEntity"/>. 
        /// This expression projects an instance of <typeparam name="TEntity"/> in <typeparam name="TKey"/>
        /// </summary>
        private readonly Expression<Func<TEntity, TKey>> _keySelector;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFDbContextRepository{TEntity,TKey}"/> class. 
        /// </summary>
        /// <param name="keySelector">
        /// The key selector.
        /// </param>
        /// <param name="dbContext">
        /// The data context.
        /// </param>
        protected EFDbContextRepository(DbContext dbContext) {
            // _dbContext.Log = Console.Out;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets the <see cref="DbContext"/> derived type instance
        /// </summary>
        protected DbContext DbContext {
            get { return _dbContext; }
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        #endregion

        #region private helper methods

        #endregion private helper methods

        #region protected hook methods
        /// <summary>
        /// Hook method called before the given <paramref name="entity"/> is deleted (<see cref="Delete"/>) 
        /// from the repository.
        /// </summary>
        /// <param name="entity">The entity that is going to be deleted.</param>
        protected virtual void BeforeDeletingEntity(TEntity entity) {
        }

        #endregion protected hook methods

        #region Implementation of IRepository<TSLEntity,string>

        /// <summary>
        /// Gets the key of the specified <paramref name="entity"/>.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The entity key</returns>
        public TKey GetKey(TEntity entity)
        {
            return _keySelector.Compile()(entity);
        }

        /// <summary>
        /// Gets an <see cref="IQueryable{T}"/> for all Entities.
        /// </summary>
        /// <returns>An <see cref="IQueryable{TSLEntity}"/> for all Entities</returns>
        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        /// Gets an <see cref="IPagedList{TEntity}"/> for the all entities.
        /// </summary>
        /// <param name="pageIndex">
        /// The required page number (0 based).
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="sortingCriteria">A coma separated list of property/field names from <typeparamref name="TEntity"/>
        /// of the ordering being specified, followed optionally, by ascending or descending string. If empty string or null,
        /// the default (undetermined) sort criteria is used.
        /// <example>
        /// "Date", "Date ascending" - "Date, Kind descending".
        /// </example>
        /// </param>
        /// <returns>
        /// A <see cref="IPagedList{TEntity}"/> for all Entities
        /// </returns>
        public IPagedList<TEntity> GetAll(int pageIndex, int pageSize, string sortingCriteria)
        {
            IQueryable<TEntity> entities = GetAll();

            // TODO: Use dynamic to filter
            //if (String.IsNullOrEmpty(sortingCriteria) == false) {
            //    entities = entities.OrderBy(sortingCriteria);
            //}
            
            return entities.ToPagedList(pageIndex, pageSize);
        }

        /// <summary>
        /// Gets an <see cref="IPagedList{TEntyty}"/> for the all entities complying with the specified <paramref name="filterCriteria"/>.
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
        /// of the ordering being specified, followed optionally, by ascending or descending string. If empty string or null,
        /// the default (undetermined) sort criteria is used.
        /// <example>
        /// "Date", "Date ascending" - "Date, Kind descending".
        /// </example>
        /// </param>
        /// <returns>
        /// A <see cref="IPagedList{Photographer}"/> for all photographers.
        /// </returns>
        public IPagedList<TEntity> GetAll(string filterCriteria, int pageIndex, int pageSize, string sortingCriteria)
        {
            IQueryable<TEntity> entities = GetAll();

            // TODO: Use dynamic to filter
            //if (String.IsNullOrEmpty(filterCriteria) == false) {
            //    entities = entities.Where(filterCriteria);
            //}

            // TODO: Use dynamic to filter
            //if (String.IsNullOrEmpty(sortingCriteria) == false) {
            //    entities = entities.OrderBy(sortingCriteria);
            //}
            
            return entities.ToPagedList(pageIndex, pageSize);
        }

        /// <summary>
        /// Gets an entity given the specified <paramref name="entityId"/>.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns></returns>
        public TEntity Get(TKey entityId) {
            TEntity entity = _dbSet.Find(entityId);
            return entity;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public void Update(TEntity entity)
        {
        }

        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        public void UpdateAll(params TEntity[] entities) {
            
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entityId">The key of the entity to delete.</param>
        public void Delete(TKey entityId)
        {
            TEntity e = Get(entityId);
            BeforeDeletingEntity(e);
            _dbSet.Remove(e);
        }

        /// <summary>
        /// Saves permanently all changes made to the repository.
        /// </summary>
        public void Save() {
            _dbContext.SaveChanges();
        }

        #endregion
    }
}