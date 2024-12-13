using System.Linq.Expressions;

namespace UnalColombia.Geomatic.Geodb.Common.Infrastructure
{
    /// <summary>
    /// Base repository contract for database access (async mode)
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepositoryAsync<T> where T : class
    {
        #region Methods

        /// <summary>
        /// Method that obtains an entity from its id
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Entidad</returns>
        Task<T> GetByIdAsync(object id);

        /// <summary>
        /// Method that obtains all database objects according to a filter
        /// </summary>
        /// <param name="filter">Lamda expresion to filter</param>
        /// <returns>IQueryable of the Entity</returns>
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Method that allows adding multiple entities asynchronously
        /// </summary>
        /// <param name="entities">Entities to add</param>
        /// <param name="saveChanges">Determines if that operation have to save into database</param>
        /// <returns>Task</returns>
        Task AddAsync(IEnumerable<T> entities, bool saveChanges = true);

        /// <summary>
        /// Method that allows adding only one entity asynchronously
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <param name="saveChanges">Determines if that operation have to save into database</param>
        /// <returns>Task</returns>
        Task<T> AddAsync(T entity, bool saveChanges = true);

        /// <summary>
        /// Method that allows editing only one entity asynchronously
        /// </summary>
        /// <param name="entity">Entity to edit</param>
        /// <param name="saveChanges">Determines if that operation have to save into database</param>

        /// <returns></returns>
        Task<T> UpdateAsync(T entity, bool saveChanges = true);

        /// <summary>
        /// Method that allows deleting only one entity asynchronously
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <param name="saveChanges">Determines if that operation have to save into database</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(object id, bool saveChanges = true);

        /// <summary>
        /// Method that stores changes in the database asynchronously
        /// </summary>
        /// <returns>Task</returns>
        Task SaveChangesAsync();

        #endregion
    }
}
