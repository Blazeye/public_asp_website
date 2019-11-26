using System;
using System.Collections.Generic;
using System.Text;
using SKU.DataClasses;


namespace SKU.Models
{

    public interface ISubjectModel
    {
        /// <summary>
        /// add a new category to the database
        /// </summary>
        /// <param>category object</param>
        /// <returns>true is successfull or false if not successfull</returns>
        bool AddCategory(Category category);

        /// <summary>
        /// change category info
        /// </summary>
        /// <param>category object</param>
        /// <returns>true is successfull or false if not successfull</returns>
        bool UpdateCategory(Category category);

        /// <summary>
        /// add a new subject to the database
        /// </summary>
        /// <param>subject object</param>
        /// <returns>true is successfull or false if not successfull</returns>
        bool AddSubject(SubjectInfo subjectInfo);

        /// <summary>
        /// change subject info
        /// </summary>
        /// <param>subject object</param>
        /// <returns>true is successfull or false if not successfull</returns>
        bool UpdateSubject(SubjectInfo subjectInfo);

        /// <summary>
        /// get info from all subjects
        /// </summary>
        /// <returns>list of SubjectInfo objects</returns>
        List<SubjectInfo> FindAllSubjects();

        /// <summary>
        /// find and return all categories
        /// </summary>
        /// <returns>list of category objects</returns>
        List<Category> FindAllCategories();
    }
}
