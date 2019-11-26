using SkuAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SkuAppDomain.Abstract
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected IDbContext context; /*= new EFDbContext();*/

        public GenericRepository(IDbContext context)
        {
            this.context = context;
        }


        public virtual IEnumerable<T> GetAll()
        {
            return this.DataSource();
        }

        public virtual T GetById(int id)
        {
            return this.context.Set<T>().Find(id);
        }


        public virtual int GetIdByUsername(string name)
        {
            return this.context.Users.Where(m => m.username == name).Select(m => m.id).FirstOrDefault();
        }

        public virtual void InsertAndSubmit(T entity)
        {
            this.context.Set<T>().Add(entity);
            this.SaveChanges();
        }

        public virtual void UpdateAndSubmit(T entity)
        {
            this.SaveChanges();
        }

        public virtual void DeleteAndSubmit(T entity)
        {
            this.context.Set<T>().Remove(entity);
            this.SaveChanges();
        }


        public void ExecuteCommand(string sql, params object[] parameters)
        {
            this.context.ExecuteCommand(sql, parameters);
        }



        #region Private Helpers
        /// <summary>
        /// Returns expression to use in expression trees, like where
        /// statements. For example query.Where(GetExpression("IsDeleted",
        /// typeof(boolean), false));
        /// </summary>
        /// <param name="propertyName">The name of the property. Either
        /// boolean or a nullable type</param>
        /// <returns></returns>
        private Expression<Func<T, bool>> GetExpression(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(T));
            var actualValueExpression = Expression.Property(param, propertyName);

            var lambda = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(actualValueExpression,
                    Expression.Constant(value)),
                param);

            return lambda;
        }

        protected IQueryable<T> DataSource()
        {
            var query = context.Set<T>().AsQueryable<T>();
            var property = typeof(T).GetProperty("Deleted");

            if (property != null)
            {
                query = query.Where(GetExpression("Deleted", null));
            }

            return query;
        }

        protected virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }
        #endregion
    }
}
