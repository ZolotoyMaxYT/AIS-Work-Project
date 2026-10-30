using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Extended repository for DataBase with [bool IsExist(ID)]
    /// </summary>
    /// <typeparam name="T">Entity of Database</typeparam>
    public interface IRepositoryIsExist<T> where T : IDomainObject, new()
    {
        /// <summary>
        /// A record with ID is exist?
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>true - if successful, else - false</returns>
        public bool IsExist(string id);
    }
}
