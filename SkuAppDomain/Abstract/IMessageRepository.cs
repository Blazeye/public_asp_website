using SkuAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuAppDomain.Abstract
{
    public interface IMessageRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        int GetIdByUsername(string name);

        void InsertAndSubmit(T entity);

        void UpdateAndSubmit(T entity);

        void DeleteAndSubmit(T entity);

        void ExecuteCommand(string sql, params object[] parameters);

        Message SaveNewMessage(string item, string message, int? userid, int visibleToRoleId, byte marked, byte followup, int followupUser);

        Comment SaveNewComment(string comment, int? userid, byte marked, int messageid);
    }
}
