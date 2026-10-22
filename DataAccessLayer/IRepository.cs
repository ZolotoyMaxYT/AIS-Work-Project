using Model;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject, new()
    {
        public bool Create(T entity);
        public bool Update(T entity);
        public bool Delete(string id);
        public bool IsExist(string id);
        public T[] ReadAll();
        public T? ReadByID(string id);
    }
}
