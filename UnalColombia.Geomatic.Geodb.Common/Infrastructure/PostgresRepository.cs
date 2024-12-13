using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UnalColombia.Geomatic.Geodb.Common.Exceptions;

namespace UnalColombia.Geomatic.Geodb.Common.Infrastructure
{
    public class PostgresRepository<TEntity, TDbContext> : IRepositoryAsync<TEntity>
         where TEntity : class, new()
         where TDbContext : DbContext
    {
        protected TDbContext _db;
        protected DbSet<TEntity> _model;

        /// <summary>
        /// Create an instance of the class
        /// </summary>
        /// <param name="context">Context to be managed</param>
        public PostgresRepository(TDbContext context)
        {
            _db = context;
            _model = _db.Set<TEntity>();
        }

        /// <summary>
        /// Method that obtains all database objects according to a filter
        /// </summary>
        /// <param name="filter">Lamda expresion to filter</param>
        /// <returns>IQueryable of the Entity</returns>
        public IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return _model.Where(filter);
        }

        /// <summary>
        /// Method that obtains an entity from its id
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Entidad</returns>
        /// <exception cref="BusinessRuleException"></exception>

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _model.FindAsync(id) ?? throw new BusinessRuleException("Not found");
        }

        /// <summary>
        /// Method that allows adding multiple entities asynchronously
        /// </summary>
        /// <param name="entities">Entities to add</param>
        /// <returns>Task</returns>
        public async Task AddAsync(IEnumerable<TEntity> entities, bool saveChanges = true)
        {
            await _model.AddRangeAsync(entities);
            if (saveChanges)
                await SaveChangesAsync();
        }

        /// <summary>
        /// Method that allows adding only one entity asynchronously
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>Entity created</returns>
        public async Task<TEntity> AddAsync(TEntity entity, bool saveChanges = true)
        {
            try
            {
                var res = (await _model.AddAsync(entity));
                if (saveChanges)
                    await SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                throw new DataBaseException<TEntity>(entity, TypeOperation.CREATE, ex);
            }
        }

        /// <summary>
        /// Method that allows editing an entity
        /// </summary>
        /// <param name="entity">Entity to edit</param>
        /// <returns>Entity updated</returns>
        /// <exception cref="DataBaseException"></exception>
        public async Task<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true)
        {
            try
            {
                var res = _model.Update(entity);
                if (saveChanges)
                    await SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                throw new DataBaseException<TEntity>(entity, TypeOperation.CREATE, ex);
            }
        }

        /// <summary>
        /// Method that allows multiple entities
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>True: operation Usccessfull| False: Operation Failed</returns>
        /// <exception cref="DataBaseException"></exception>
        public async Task<bool> DeleteAsync(object id, bool saveChanges = true)
        {
            var entity = await GetByIdAsync(id);
            try
            {
                _model.Remove(entity);
                if (saveChanges)
                    await SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new DataBaseException<TEntity>(entity, TypeOperation.CREATE, ex);
            }

        }

        /// <summary>
        /// Method that stores changes in the database asynchronously
        /// </summary>
        /// <returns>Task</returns>
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
