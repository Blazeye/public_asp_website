using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SKU.Models;
using SKU.CRUD;
using SKU.DataClasses;

namespace DataModels.tests
{
    [TestFixture]
    class TestUserModel
    {
        Crud crud = new Crud("localhost", "super_awesome_child_farm", "kinderboer", "waitword");

        [Test]
        public void TestFindAllUsers()
        {

            //prepare        
            UserModel dut = new UserModel(crud);

            //test
            List<UserInfo> result = dut.FindAllUsers();

            //validate
            Assert.IsNotNull(result);
            Assert.AreEqual(19, result.Count());
            Assert.AreEqual("Diederik", result[3].Name);


        }

        [Test]
        public void TestFindUserColors()
        {
            {
                //prepare        
                UserModel dut = new UserModel(crud);

                //test
                List<UserColor> result = dut.FindUserColors();

                //validate
                Assert.IsNotNull(result);
                Assert.AreEqual(10, result.Count());
                Assert.AreEqual("DeepPink", result[6].Name);
            }
        }

        [Test]
        public void TestUpdateUserInfo()
        {
            //prepare        
            UserModel dut = new UserModel(crud);

            UserInfo userInfo = new UserInfo();
            UserColor userColor = new UserColor();
            userColor.Id = 3;
            userColor.Name = "DarkGreen";

            userInfo.Id = 7;
            userInfo.Name = "testNaam";
            userInfo.Active = false;
            userInfo.Role = 5;
            userInfo.Color = userColor;

            //test
            bool result = dut.UpdateUserInfo(userInfo);

            //validate
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestCase("karin", "password", true)]
        [TestCase("karin", "asdfsadf", false)]
        [TestCase("jeanette", "password", false)]
        public void TestValidateLogin(string username, string password, bool expectedResult)
        {
            //prepare        
            UserModel dut = new UserModel(crud);

            //test
            var result = dut.ValidateLogin(username, password);

            //validate
            Assert.AreEqual(result, expectedResult);
        }
    }
}

