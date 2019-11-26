using SkuAppDomain.Abstract;
using SkuAppDomain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SkuAppDomain.Concrete
{
    public class NavRepository<T> : GenericRepository<T>, INavRepository<T> where T : class
    {
        protected new IDbContext context; 

        public NavRepository(IDbContext context) : base(context)
        {
            this.context = base.context;
        }

        public List<MenuItem> GetMenuItems(string category)
        {
            List<MenuItem> menuList = new List<MenuItem>();
            if(category != null)
            {
                menuList.Add(new MenuItem { IsCategory = true, Name = category, ParentName = category });
                int categoryId = this.context.Categories.Where(m => m.name == category).Select(i => i.id).FirstOrDefault();
                var subjectList = this.context.Subjects.Where(m => m.category_id == categoryId);
                foreach(var item in subjectList)
                {
                    menuList.Add(new MenuItem { IsCategory = false, Name = item.name, ParentName = category });
                }
                return menuList;
            }
            IList<Category> categoryList = this.context.Categories.ToList();
            foreach(var cItem in categoryList)
            {
                menuList.Add(new MenuItem { IsCategory = true, Name = cItem.name, ParentName = cItem.name });
                var subjectList = this.context.Subjects.Where(m => m.category_id == cItem.id);
                foreach(var sItem in subjectList)
                {
                    menuList.Add(new MenuItem { IsCategory = false, Name = sItem.name, ParentName = cItem.name });
                }
            }
            return menuList;
        }
    }
}
