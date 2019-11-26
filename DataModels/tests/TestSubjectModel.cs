using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SKU.CRUD;
using SKU.DataClasses;
using SKU.Models;

namespace DataModels.tests
{
    [TestFixture]
    class TestSubjectModel
    {
        Crud crud = new Crud("localhost", "super_awesome_child_farm", "kinderboer", "waitword");

        [Test]
        public void TestAddCategory()
        {
            //prepare        
            SubjectModel dut = new SubjectModel(crud);
            Category category = new Category();
            category.Name = "lamas";
            category.Active = true;

            //test
            bool result = dut.AddCategory(category);

            //validate
            Assert.IsTrue(result);
        }

        [Test]
        public void TestUpdateCategory()
        {
            //prepare
            SubjectModel dut = new SubjectModel(crud);
            Category category = new Category();
            category.Name = "lamas";
            category.Active = false;
            category.Id = 15;

            //test
            bool result = dut.UpdateCategory(category);

            //validate
            Assert.IsTrue(result);
        }

        [Test]
        public void TestAddSubject()
        {
            //prepare        
            SubjectModel dut = new SubjectModel(crud);
            Category category = new Category();
            category.Id = 5;
            SubjectInfo subject = new SubjectInfo();
            subject.Name = "schnappie";
            subject.Category = category;

            //test
            bool result = dut.AddSubject(subject);

            //validate
            Assert.IsTrue(result);
        }

        [Test]
        public void TestUpdateSubject()
        {
            //prepare
            SubjectModel dut = new SubjectModel(crud);
            Category category = new Category();
            category.Id = 15;

            SubjectInfo subject = new SubjectInfo();
            subject.Name = "Tom Poes";
            subject.Id = 13;
            subject.Active = false;
            subject.Category = category;

            //test
            bool result = dut.UpdateSubject(subject);

            //validate
            Assert.IsTrue(result);
        }

        [Test]
        public void TestFindAllSubjects()
        {
            //prepare        
            SubjectModel dut = new SubjectModel(crud);

            //test
            List<SubjectInfo> result = dut.FindAllSubjects();

            //validate
            Assert.IsNotNull(result);
            Assert.AreEqual(14, result.Count());
            Assert.AreEqual("Mara", result[2].Name);
        }

        [Test]
        public void TestFindAllCategories()
        {
            //prepare
            SubjectModel dut = new SubjectModel(crud);

            //test
            List<Category> result = dut.FindAllCategories();

            //validate
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count()); /* JH: VERY DEPENDENT ON THE CURRENT STATE OF THE DATABASE, DO NOT TEST FOR THIS */
            Assert.AreEqual("Varkens", result[4].Name); /* JH: VERY DEPENDENT ON THE CURRENT STATE OF THE DATABASE, DO NOT TEST FOR THIS */
            /* JH: You could test if Assert.IsTrue(result.Contains(x => x.Name == "Varkens"), "Varkens present"); */
        }

    }
}
