using Microsoft.VisualStudio.TestTools.UnitTesting;
using TESTT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTT.Tests
{
    [TestClass()]
    public class Login_FormTests
    {
        [TestMethod()]
        public void authorization__login_admin__Password_admin()
        {
            string login = "admin";
            string pass = "admin";
            string expected = "10";

            string ID_Check = "0";
            
            

            Login_Form c = new Login_Form();
            string actual = c.Test(login, pass);

           
            Assert.AreEqual(expected, actual);
            
            

            

            //int x = 10;
            //int y = 20;
            //int expected = 30;

            //MyCalc c = new MyCalc();
            //int actual = c.Sum(x, y);

            //Assert.AreEqual(expected, actual);
        }
    }
}
