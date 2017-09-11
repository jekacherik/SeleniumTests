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

    //[Parallelizable(ParallelScope.Fixtures)]
    public class ControlPanel : PropertiesCollection
    {

        [Test , Category("Function test Open CP")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserUserControlPanel")]
        public void CheckOpenCP(String browserName,String user)
        {
            SetUp(browserName);
            System.Threading.Thread.Sleep(3000);

            //Login in the System
            LoginPageObjects pagelogin = new LoginPageObjects();
            //Get data for test in xml
            pagelogin.Login(user, TestsInputData.AutomationSettings.Password);
            _test.Log(Status.Info, "User Login in the system");
            _extent.Flush();

            //Open CP in menu
            PageObjectCP deskPage = new PageObjectCP();

            deskPage.OpenCP();
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual("Control Panel", deskPage.labelTitle(), "Element found");
            _test.Log(Status.Info, "Open Control Panel link");
            _extent.Flush();


        }
        [Test, Category("Function test CP")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserUserControlPanel")]
        public void CheckAddNewFolder(String browserName, String user)
        {
            SetUp(browserName);
            System.Threading.Thread.Sleep(1000);

            LoginPageObjects pagelogin = new LoginPageObjects();
            //Get data for test in xml
            pagelogin.Login(user, TestsInputData.AutomationSettings.Password);

            _test.Log(Status.Info, "User Login in the system");
            _extent.Flush();

            PageObjectCP deskPage = new PageObjectCP();

            deskPage.OpenCP();
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual( "Control Panel", deskPage.labelTitle(), "Element found");
            _test.Log(Status.Info, "Open Control Panel link");
            _extent.Flush();


            deskPage.AddRowCancel();
            _test.Log(Status.Info, "Open Control Panel link and Click Add Row button");
            _extent.Flush();
        }

    }
}
