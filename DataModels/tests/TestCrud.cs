using System;
using System.Collections.Generic;
using System.Text;
using SKU.CRUD;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace SKU.tests
{
    [TestFixture]
    class TestCrud /* JH: TIP A testFixture should create it's own database based on a sql create tables script instead of using a production database */
    {//NS: TODO, herschrijf testcase 1 zodat userid dynamisch geset wordt.
        [TestCase("INSERT INTO user (username, password) VALUES ('sjaak', 'trekhaak')", 16)]
        [TestCase("UPDATE user SET password='testpassword' WHERE id = 4", 1)]
        [TestCase("DELETE FROM user WHERE username = 'Jan'", 1)]
        [TestCase("DELETE user", 0)]
        [TestCase("Zijn hier ook lama's?", 0)]
        public void TestNonQuery(string query, int expectedResult)
        {
            //prepare
            Crud dut = new Crud("localhost", "super_awesome_child_farm", "kinderboer", "waitword");

            //test
            var result = dut.NonQuery(query);

            //validate
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void TestSelectIdQuery()
        {
            //prepare
            Crud dut = new Crud("localhost", "super_awesome_child_farm", "kinderboer", "waitword");

            //test
            var result = dut.SelectQuery("SELECT id FROM user WHERE username = 'Marco'");

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].Count, "1 keys");
            int userId = int.Parse(result[0]["id"]);
            Assert.AreEqual(2, userId);
        }

        [Test]
        public void TestSelectRoleQuery()
        {
            //prepare
            Crud dut = new Crud("localhost", "super_awesome_child_farm", "kinderboer", "waitword");

            //test
            var result = dut.SelectQuery("SELECT username FROM user WHERE role = 5");

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(3, result.Count); /* JH: VERY DEPENDEND ON THE CURRENT STATE OF THE DATABASE, DO NOT USE THAT */
        }

        [Test]
        public void TestSelectFalseQuery()
        {
            //prepare
            Crud dut = new Crud("localhost", "super_awesome_child_farm", "kinderboer", "waitword");

            //test
            var result = dut.SelectQuery("Werkt Marco nog bij de kinderboerderij?");

            Assert.IsNull(result);
        }
    }
}
