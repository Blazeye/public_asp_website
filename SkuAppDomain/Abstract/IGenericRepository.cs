using System.Collections.Generic;

namespace SkuAppDomain.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        int GetIdByUsername(string name);

        void InsertAndSubmit(T entity);

        void UpdateAndSubmit(T entity);

        void DeleteAndSubmit(T entity);

        void ExecuteCommand(string sql, params object[] parameters);

    }
}
