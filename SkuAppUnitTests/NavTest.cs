using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkuAppDomain.Abstract;
using SkuAppDomain.Concrete;
using SkuAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SkuAppUnitTests
{
    [TestClass]
    public class RepositoryTest
    {

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Behavior_When_Category_Is_Null()
        {
            // arrange
            var cat = new Category { id = 1, name = "caramel" };
            var sub = new Subject { id = 1, name = "Twix", category_id = 1 };

            Mock<IDbContext> mock = new Mock<IDbContext>();
            mock.Setup(m => m.Categories.Add(cat))
                .Returns((Category u) => u);
            mock.Setup(m => m.Subjects.Add(sub))
                .Returns((Subject u) => u);

            NavRepository<Category> repository = new NavRepository<Category>(mock.Object);

            string category = null;


            // act
            var result = repository.GetMenuItems(category);

        }

        [TestMethod]
        public void Can_Create_Categories()
        {
            // arrange
            var cat = new List<Category>
            {
                new Category { id = 1, name = "caramel" },
                new Category { id = 2, name = "chocolate" },
            }.AsQueryable();

            var sub = new List<Subject>
            {
                new Subject { id = 1, name = "Twix", category_id = 1 },
                new Subject { id = 2, name = "Lion", category_id = 1 },
                new Subject { id = 3, name = "Smarties", category_id = 2 },
                new Subject { id = 4, name = "Snickers", category_id = 1 },
                new Subject { id = 5, name = "Bounty", category_id = 2 },
            }.AsQueryable();

            var categoriesMock = new Mock<IDbSet<Category>>();
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(cat.Provider);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(cat.Expression);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(cat.ElementType);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(cat.GetEnumerator());

            var subjectsMock = new Mock<IDbSet<Subject>>();
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.Provider).Returns(sub.Provider);
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.Expression).Returns(sub.Expression);
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.ElementType).Returns(sub.ElementType);
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.GetEnumerator()).Returns(sub.GetEnumerator());

            Mock<IDbContext> mock = new Mock<IDbContext>();
            mock.Setup(m => m.Categories)
                .Returns(categoriesMock.Object);
            mock.Setup(m => m.Subjects)
                .Returns(subjectsMock.Object);

            NavRepository<Category> repository = new NavRepository<Category>(mock.Object);


            // act
            var results = repository.GetMenuItems("caramel");


            // assert
            Assert.AreEqual(results.Count, 4);
            Assert.AreEqual(results[0].Name, "caramel");
            Assert.AreEqual(results[1].Name, "Twix");
            Assert.AreEqual(results[2].Name, "Lion");
            Assert.AreEqual(results[3].Name, "Snickers");
        }

        [TestMethod]
        public void Can_Save_New_Message()
        {
            var cat = new List<Category>
            {
                new Category
                {
                    id = 1, name = "caramel",
                    active = 1, is_dier = 1,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                },
            }.AsQueryable();

            var sub = new List<Subject>
            {
                new Subject
                {
                    id = 1,
                    name = "Twix",
                    category_id = 1,
                    active = 1,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                },
            }.AsQueryable();

            var user = new List<User>
            {
                new User
                {
                    id = 1,
                    active = 1,
                    color = 1,
                    username = "Jimmy",
                    encrypted_password = "Mast",
                    role = 1,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    last_logout = DateTime.Now
                },
            }.AsQueryable();

            var categoriesMock = new Mock<IDbSet<Category>>();
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(cat.Provider);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(cat.Expression);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(cat.ElementType);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(cat.GetEnumerator());

            var subjectsMock = new Mock<IDbSet<Subject>>();
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.Provider).Returns(sub.Provider);
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.Expression).Returns(sub.Expression);
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.ElementType).Returns(sub.ElementType);
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.GetEnumerator()).Returns(sub.GetEnumerator());

            var usersMock = new Mock<IDbSet<User>>();
            usersMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(user.Provider);
            usersMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(user.Expression);
            usersMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(user.ElementType);
            usersMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(user.GetEnumerator());

            Mock<IDbContext> mock = new Mock<IDbContext>();
            mock.Setup(m => m.Categories)
                .Returns(categoriesMock.Object);
            mock.Setup(m => m.Subjects)
                .Returns(subjectsMock.Object);
            mock.Setup(m => m.Users)
                .Returns(usersMock.Object);
            mock.Setup(m => m.Subjects.Find(It.IsAny<int>()))
                .Returns(new Subject
                {
                    id = 1,
                    category_id = 1,
                    name = "Twix",
                    active = 1,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                });

            MessageRepository<Category> repository = new MessageRepository<Category>(mock.Object);

            Message test = new Message
            {
                message = "sup",
                category_id = 1,
                subject_id = 1,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                followup = 1,
                marked = 1,
                user_id = 1,
                visible_for_role_id = 1
            };


            // act
            var result = repository.SaveNewMessage("Twix", "sup", 1, 1, 1, 1);


            // assert
            Assert.AreEqual(test.GetType(), result.GetType());
            Assert.AreEqual(test.id, result.id);
            Assert.AreEqual(test.category_id, result.category_id);
            Assert.AreEqual(test.followup, result.followup);
            Assert.AreEqual(test.marked, result.marked);
            Assert.AreEqual(test.message, result.message);
            Assert.AreEqual(test.visible_for_role_id, result.visible_for_role_id);
            Assert.AreEqual(test.user_id, result.user_id);
            Assert.AreEqual(test.subject_id, result.subject_id);

        }

        [TestMethod]
        public void Cant_Save_Message_Without_User_Id()
        {
            var cat = new List<Category>
            {
                new Category
                {
                    id = 1, name = "caramel",
                    active = 1, is_dier = 1,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                },
            }.AsQueryable();

            var sub = new List<Subject>
            {
                new Subject
                {
                    id = 1,
                    name = "Twix",
                    category_id = 1,
                    active = 1,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                },
            }.AsQueryable();

            var user = new List<User>
            {
                new User
                {
                    id = 1,
                    active = 1,
                    color = 1,
                    username = "Jimmy",
                    encrypted_password = "Mast",
                    role = 1,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    last_logout = DateTime.Now
                },
            }.AsQueryable();

            var categoriesMock = new Mock<IDbSet<Category>>();
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(cat.Provider);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(cat.Expression);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(cat.ElementType);
            categoriesMock.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(cat.GetEnumerator());

            var subjectsMock = new Mock<IDbSet<Subject>>();
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.Provider).Returns(sub.Provider);
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.Expression).Returns(sub.Expression);
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.ElementType).Returns(sub.ElementType);
            subjectsMock.As<IQueryable<Subject>>().Setup(m => m.GetEnumerator()).Returns(sub.GetEnumerator());

            var usersMock = new Mock<IDbSet<User>>();
            usersMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(user.Provider);
            usersMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(user.Expression);
            usersMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(user.ElementType);
            usersMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(user.GetEnumerator());

            Mock<IDbContext> mock = new Mock<IDbContext>();
            mock.Setup(m => m.Categories)
                .Returns(categoriesMock.Object);
            mock.Setup(m => m.Subjects)
                .Returns(subjectsMock.Object);
            mock.Setup(m => m.Users)
                .Returns(usersMock.Object);
            mock.Setup(m => m.Subjects.Find(It.IsAny<int>()))
                .Returns(new Subject
                {
                    id = 1,
                    category_id = 1,
                    name = "Twix",
                    active = 1,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                });

            MessageRepository<Category> repository = new MessageRepository<Category>(mock.Object);

            Message test = new Message
            {
                message = "sup",
                category_id = 1,
                subject_id = 1,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                followup = 1,
                marked = 1,
                user_id = 1,
                visible_for_role_id = 1
            };


            // act
            var result = repository.SaveNewMessage("Twix", "sup", null, 1, 1, 1);

            // assert
            Assert.IsNull(result);

        }

        [TestMethod]
        public void Can_Save_New_Comment()
        {
            string comment = "sup";
            byte marked = 1;
            int? userid = 1;
            int messageid = 1;

            Mock<IDbContext> mock = new Mock<IDbContext>();
            MessageRepository<Comment> repository = new MessageRepository<Comment>(mock.Object);

            var test = new Comment
            {
                comment = "sup",
                marked = 1,
                user_id = 1,
                message_id = 1,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };


            // act

            var result = repository.SaveNewComment(comment, userid, marked, messageid);


            // assert

            Assert.AreEqual(test.GetType(), result.GetType());
            Assert.AreEqual(test.id, result.id);
            Assert.AreEqual(test.marked, result.marked);
            Assert.AreEqual(test.message_id, result.message_id);
            Assert.AreEqual(test.user_id, result.user_id);
            Assert.AreEqual(test.comment, result.comment);
        }

        [TestMethod]
        public void Cant_Save_New_Comment_Without_User_Id()
        {
            string comment = "sup";
            byte marked = 1;
            int? userid = null;
            int messageid = 1;

            Mock<IDbContext> mock = new Mock<IDbContext>();
            MessageRepository<Comment> repository = new MessageRepository<Comment>(mock.Object);

            var test = new Comment
            {
                comment = "sup",
                marked = 1,
                user_id = 1,
                message_id = 1,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };


            // act

            var result = repository.SaveNewComment(comment, userid, marked, messageid);


            // assert

            Assert.IsNull(result);
        }
    }
}

