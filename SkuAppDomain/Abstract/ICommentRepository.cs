using SkuAppDomain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SkuAppDomain.Abstract
{
    public interface ICommentRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        int GetIdByUsername(string name);

        void InsertAndSubmit(T entity);

        void UpdateAndSubmit(T entity);

        void DeleteAndSubmit(T entity);

        void ExecuteCommand(string sql, params object[] parameters);

        List<LogComment> FilterComments(int role);
    }
}
