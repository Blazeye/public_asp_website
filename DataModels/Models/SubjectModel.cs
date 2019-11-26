using System;
using System.Collections.Generic;
using System.Text;
using SKU.CRUD;
using SKU.DataClasses;
using log4net;

namespace SKU.Models
{

    public class SubjectModel : ISubjectModel
    {
        private static ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Crud Crud { get; }

        public SubjectModel(Crud crud)
        {
            Crud = crud;
        }

        public bool AddCategory(Category category)
        {
            string name = category.Name;
            string isAnimal = category.IsAnimal ? "1" : "0";
            string active = category.Active ? "1" : "0"; 

            var result = Crud.NonQuery("INSERT INTO category (active, is_dier, name, created_at, updated_at) "+
                                       "VALUES ('" + active + "', '" + isAnimal + "', '" + name + "', now(), now())");

            if (result > 0)
            {
                return true;
            }
            else
            {
                LOG.Info("unsuccesfull category insertquery");
                return false;
            }
        }


        public bool UpdateCategory(Category category)
        {
            string id = category.Id.ToString();
            string name = category.Name;
            string isAnimal = category.IsAnimal ? "1" : "0";
            string active = category.Active ? "1" : "0";

            int result = (int)Crud.NonQuery("UPDATE category SET name='" + name +
                                                              "', active= '" + active +
                                                              "', is_dier= '" + isAnimal +
                                                              "', updated_at = now()" +
                                                              " WHERE id='" + id + "'");
            if (result == 1)
            {
                return true;
            }
            LOG.Info("unsuccesful update category query");
            return false;
        }

        public bool AddSubject(SubjectInfo subjectInfo)
        {
            string name = subjectInfo.Name;
            string category = subjectInfo.Category.Id.ToString();

            var result = Crud.NonQuery("INSERT INTO subject (category_id, name, created_at, updated_at) values ('" + category + "', '" + name + "', now(), now())");

            if (result > 0)
            {
                return true;
            }
            else
            {
                LOG.Info("unsuccesfull insert subject query");
                return false;
            }
        }

        public bool UpdateSubject(SubjectInfo subject)
        {
            string id = subject.Id.ToString();
            string name = subject.Name;
            string category = subject.Category.Id.ToString();
            string active;
            if (subject.Active)
            {
                active = "1";
            }
            else
            {
                active = "0";
            }
            //
            int result = (int)Crud.NonQuery("UPDATE subject SET name='" + name +
                                                              "', active= '" + active +
                                                              "', category_id='" + category +
                                                              "', updated_at = now()" +
                                                              " WHERE id='" + id + "'");
            if (result == 1)
            {
                return true;
            }
            LOG.Info("Unsuccessfull update subject query");
            return false;
        }

        public List<SubjectInfo> FindAllSubjects()
        {
            List<SubjectInfo> allSubjects = new List<SubjectInfo>();

            List<Dictionary<string, string>> result = Crud.SelectQuery("SELECT subject.*, category.name as category_name, category.active as category_active " +
                                                                        "FROM subject LEFT JOIN category ON subject.category_id = category.id");

            if (result != null)
            {
                foreach (var subjectProperties in result)
                {
                    SubjectInfo subject = new SubjectInfo();
                    subject.Id = int.Parse(subjectProperties["id"]);
                    subject.Active = bool.Parse(subjectProperties["active"]);
                    subject.Name = subjectProperties["name"];

                    Category category = new Category();
                    category.Id = int.Parse(subjectProperties["category_id"]);
                    category.Name = subjectProperties["category_name"];
                    category.Active = bool.Parse(subjectProperties["category_active"]);
                    subject.Category = category;

                    allSubjects.Add(subject);
                }
                return allSubjects;
            }
            LOG.Info("no results returned with FindAllUsers()");
            return null;
        }

        public List<Category> FindAllCategories()
        {
            List<Category> allCategories = new List<Category>();

            List<Dictionary<string, string>> result = Crud.SelectQuery("SELECT * FROM category");
            if (result != null)
            {
                foreach (var categoryProperties in result)
                {
                    Category category = new Category();
                    category.Id = int.Parse(categoryProperties["id"]);
                    category.Name = categoryProperties["name"];
                    category.Active = bool.Parse(categoryProperties["active"]);
                    category.IsAnimal = bool.Parse(categoryProperties["is_dier"]);

                    allCategories.Add(category);
                }
                return allCategories;
            }
            LOG.Info("no results return with FindAllCategories");
            return null;
        }
    }
}


