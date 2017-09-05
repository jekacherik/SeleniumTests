using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using PlmonFuncTestNunit.PageObjects;
using PlmonFuncTestNunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.Tests
{
    [TestFixture]

    //[Parallelizable]
    public class ControlPanel : PropertiesCollection
    {
        [Test , Category("Function test Open CP")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserUser")]
        public void CheckOpenCP(String browserName,String user)
        {
            SetUp(browserName);
            System.Threading.Thread.Sleep(3000);

            //Login in the System
            LoginPageObjects pagelogin = new LoginPageObjects();
            //Get data for test in xml
            pagelogin.Login(user, TestsInputData.AutomationSettings.Password);
            System.Threading.Thread.Sleep(1000);
            string DeskURL = driver.Url;
            string message = "login faild";
            Char delimiter = '?';
            String[] substrings = DeskURL.Split(delimiter);
            var parseDesk = substrings[0];
            Assert.AreEqual(parseDesk, TestsInputData.AutomationSettings.Desk, message);

            _test.Log(Status.Info, "User Login in the system");
            _extent.Flush();

            //Open CP in menu

            PageObjectCP deskPage = new PageObjectCP();

            deskPage.OpenCP();
            Assert.AreEqual(deskPage.labelTitle(), "Control Panel", "Element found");
            _test.Log(Status.Info, "Open Control Panel link");
            _extent.Flush();


        }
        [Test, Category("Function test CP")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserUser1")]
        public void CheckAddNewFolder(String browserName, String user)
        {
            SetUp(browserName);
            System.Threading.Thread.Sleep(1000);

            LoginPageObjects pagelogin = new LoginPageObjects();
            //Get data for test in xml
            pagelogin.Login(user, TestsInputData.AutomationSettings.Password);
            string DeskURL = driver.Url;
            string message = "login faild";
            Char delimiter = '?';
            String[] substrings = DeskURL.Split(delimiter);
            var parseDesk = substrings[0];
            Assert.AreEqual(TestsInputData.AutomationSettings.Desk, parseDesk, message);

            _test.Log(Status.Info, "User Login in the system");
            _extent.Flush();

            PageObjectCP deskPage = new PageObjectCP();

            deskPage.OpenCP();
            Assert.AreEqual(deskPage.labelTitle(), "Control Panel", "Element found");
            _test.Log(Status.Info, "Open Control Panel link");
            _extent.Flush();


            deskPage.AddRowCancel();
            _test.Log(Status.Info, "Open Control Panel link and Click Add Row button");
            _extent.Flush();
        }

    }
}
