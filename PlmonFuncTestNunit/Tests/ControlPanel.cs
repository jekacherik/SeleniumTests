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
        [TestCaseSource(typeof(PropertiesCollection), "BrowserUserControlPanel")]
        public void CheckOpenCP(String browserName,String user)
        {
            SetUp(browserName,user);
            //Open CP in menu
            var deskPage = _pages.GetPage<PageObjectCP>();

            deskPage.OpenCP();
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual("Control Panel", deskPage.labelTitle(), "Element found");
            _test.Log(Status.Info, "Open Control Panel link");
            _extent.Flush();


        }
        [Test, Category("Function test Open CP")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserUserControlPanel")]
        public void CheckAddNewFolder(String browserName, String user)
        {
            SetUp(browserName,user);
            var deskPage = _pages.GetPage<PageObjectCP>();

            deskPage.OpenCP();
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual( "Control Panel", deskPage.labelTitle(), "Element found");
            _test.Log(Status.Info, "Open Control Panel link");
            _extent.Flush();


            deskPage.AddRowCancel();
            _test.Log(Status.Info, "Open Control Panel link and Click Add Row button");
            _test.Log(Status.Info, "Open Control Panel link and Click Add Row Cancel");
            _extent.Flush();
        }

    }
}
