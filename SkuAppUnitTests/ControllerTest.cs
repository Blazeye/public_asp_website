using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkuApplication.Models;
using SkuAppDomain.Entities;
using System.Collections.Generic;
using SkuApplication.Controllers;
using SkuAppDomain.Abstract;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SkuAppDomain.Concrete;
using System.Data.Entity;

namespace SkuAppUnitTests
{
    [TestClass]
    public class NavTest
    {
        [TestMethod]
        public void Can_Filter_Comments()
        {

            Mock<IGenericRepository<Message>> mock1 = new Mock<IGenericRepository<Message>>();
            mock1.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(new Message { });

            Mock<ICommentRepository<Comment>> mock2 = new Mock<ICommentRepository<Comment>>();
            mock2.Setup(m => m.FilterComments(It.IsAny<int>()))
                .Returns(new List<LogComment>() {
                            new LogComment { Id = 1, Username = "P1", Category = "Cat1", Color = "black", UpdatedDate = DateTime.Now },
                            new LogComment { Id = 2, Username = "P2", Category = "Cat2", Color = "red", UpdatedDate = DateTime.Now },
                            new LogComment { Id = 3, Username = "P3", Category = "Cat1", Color = "orange", UpdatedDate = DateTime.Now },
                            new LogComment { Id = 4, Username = "P4", Category = "Cat2", Color = "green", UpdatedDate = DateTime.Now },
                            new LogComment { Id = 5, Username = "P5", Category = "Cat3", Color = "yellow", UpdatedDate = DateTime.Now }
                });

            HomeController controller = new HomeController(mock1.Object, mock2.Object);

            // act
            var result = ((CommentListViewModel)controller.Index("Cat2", null, null, null, null).Model).CommentList;

            // assert
            Assert.AreEqual(result.Count, 2);
            Assert.IsTrue(result[0].Username == "P2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Username == "P4" && result[1].Category == "Cat2");
            Assert.IsTrue(result[1].Color == "green" && result[1].Category == "Cat2");
        }


        [TestMethod]
        public void Can_Get_Categories()
        {
            // arrange
            Mock<INavRepository<Category>> mock = new Mock<INavRepository<Category>>();
            mock.Setup(m => m.GetMenuItems(It.IsAny<string>()))
                .Returns(new List<MenuItem>
                {
                    new MenuItem { Name = "Twix", IsCategory = true, ParentName = "Round" },
                    new MenuItem { Name = "Twix", IsCategory = true, ParentName = "Square" },
                    new MenuItem { Name = "Smarties", IsCategory = true, ParentName = "Square" },
                    new MenuItem { Name = "Lion", IsCategory = true, ParentName = "Square" },
                });

            NavController target = new NavController(mock.Object);

            // act
            var results = ((NavMenuViewModel)target.Menu().Model).MenuCatItems;

            // assert
            Assert.AreEqual(results.Count, 4);
            Assert.AreEqual(results[0].Name, "Twix");
            Assert.AreEqual(results[3].Name, "Lion");
            Assert.AreEqual(results[0].ParentName, "Round");
            Assert.AreEqual(results[2].ParentName, "Square");
        }


        [TestMethod]
        public void Can_Highlight_Category()
        {
            // arrange
            Mock<INavRepository<Category>> mock = new Mock<INavRepository<Category>>();
            mock.Setup(m => m.GetMenuItems(It.IsAny<string>()))
                .Returns(new List<MenuItem>
                {
                    new MenuItem { IsCategory = false, Name = "Twix", ParentName = "caramel" },
                    new MenuItem { IsCategory = false, Name = "Snickers", ParentName = "nuts" },
                    new MenuItem { IsCategory = true, Name = "caramel", ParentName = "caramel" },
                    new MenuItem { IsCategory = true, Name = "nuts", ParentName = "nuts" },
                    new MenuItem { IsCategory = false, Name = "Lion", ParentName = "caramel" }
                });

            NavController target = new NavController(mock.Object);
            string categoryToSelect = "Lion";

            // act
            var result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // assert
            Assert.AreEqual(categoryToSelect, result);

            //// arrange
            //Mock<ICommentRepository> mock = new Mock<ICommentRepository>();
            //mock.Setup(m => m.Comments)
            //    .Returns(new List<LogComment>
            //    {
            //            new LogComment { Id = 1, Username = "P1", Category = "Twix" },
            //            new LogComment { Id = 5, Username = "P2", Category = "Lion" }
            //    });

            //NavController target = new NavController(mock.Object);
            //string categoryToSelect = "Lion";

            //// act 
            //var result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            //// assert
            //Assert.AreEqual(categoryToSelect, result);
        }



        //    [TestMethod]
        //    public void Can_Create_Categories()
        //    {
        //        // arrange
        //        Mock<ICommentRepository> mock = new Mock<ICommentRepository>();
        //        mock.Setup(m => m.Comments)
        //            .Returns(new List<LogComment>
        //            {
        //                new LogComment { Id = 1, Username = "P1", Category = "Twix" },
        //                new LogComment { Id = 2, Username = "P2", Category = "Twix" },
        //                new LogComment { Id = 3, Username = "P3", Category = "Smarties" },
        //                new LogComment { Id = 4, Username = "P4", Category = "Lion" },
        //            });

        //        NavController target = new NavController(mock.Object);

        //        // act
        //        var results = ((IEnumerable<string>)target.Menu().Model).ToArray();

        //        // assert
        //        Assert.AreEqual(results.Length, 3);
        //        Assert.AreEqual(results[0], "Lion");
        //        Assert.AreEqual(results[1], "Smarties");
        //        Assert.AreEqual(results[2], "Twix");
        //    }
        //    [TestMethod]
        //    public void Can_Highlight_Category()
        //    {
        //        // arrange
        //        Mock<ICommentRepository> mock = new Mock<ICommentRepository>();
        //        mock.Setup(m => m.Comments)
        //            .Returns(new List<LogComment>
        //            {
        //                new LogComment { Id = 1, Username = "P1", Category = "Twix" },
        //                new LogComment { Id = 5, Username = "P2", Category = "Lion" }
        //            });

        //        NavController target = new NavController(mock.Object);
        //        string categoryToSelect = "Lion";

        //        // act 
        //        var result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

        //        // assert
        //        Assert.AreEqual(categoryToSelect, result);
        //    }

    }
}
