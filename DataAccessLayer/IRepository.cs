using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Base repository for DataBase
    /// </summary>
    /// <typeparam name="T">Entity of Database</typeparam>
    public interface IRepository<T> where T : IDomainObject, new()
    {

        /// <summary>
        /// Adds a new record to the database with a unique ID.
        /// </summary>
        /// <param name="entity">data</param>
        /// <returns>true - if successful, else - false</returns>
        public bool Create(T entity);

        /// <summary>
        /// Save a record in the database.
        /// </summary>
        /// <param name="entity">data</param>
        /// <returns>true - if successful, else - false</returns>
        public bool Update(T entity);

        /// <summary>
        /// Delete a record from the database by ID.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>true - если успешно, иначе - false</returns>
        public bool Delete(string id);

        /// <summary>
        /// Get array of all records
        /// </summary>
        /// <returns>all records</returns>
        public T[] ReadAll();

        /// <summary>
        /// Get a record by ID or null.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>record or null</returns>
        public T? ReadByID(string id);
    }
}
