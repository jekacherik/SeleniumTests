using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using PlmonFuncTestNunit.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace PlmonFuncTestNunit.Tests
{
    [TestFixture]

    [Parallelizable]
    public class Style : PropertiesCollection
    {
        [Test, Category("Function test Open CP")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserStyle")]
        public void CheckOpenStyle(String browserName, String user)
        {
            //Init Driver go to URL
            System.Threading.Thread.Sleep(3000);
            SetUp(browserName);
            System.Threading.Thread.Sleep(3000);

            //Login in the System
            LoginPageObjects pagelogin = new LoginPageObjects();
            //Get data for test in xml
            pagelogin.Login(user, TestsInputData.AutomationSettings.Password);

            //Add info to the Log
            _test.Log(Status.Info, "User Login in the system");
            _extent.Flush();

            // Go To Style Folder
            PageObjectStyle pageStyle = new PageObjectStyle();
            _test.Log(Status.Info, "Go to Style Folder");
            _extent.Flush();
            pageStyle.btnStyleDesk.Click();
            System.Threading.Thread.Sleep(3000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementExists((By.Id("lblHeader"))));
            Assert.AreEqual("Style Folder", pageStyle.lblHeader.Text, "Text not found!!!");

            //Click Row in Header 
            pageStyle.rowHeader.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementExists((By.Id("btnSearch"))));
            new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementIsVisible((By.Id("btnSearch"))));
            pageStyle.btnSearch.Click();
            System.Threading.Thread.Sleep(5000);
            string URL = driver.Url;
            Char deli = '?';
            String[] substr = URL.Split(deli);
            var parseUrl = substr[0];
            string screenShotPath;
            screenShotPath = Capture(driver, "testScreen");
            if (parseUrl == "http://uiprototype80.dyn.yuniquecloud.com/plmOn/CustomError.aspx")
            {
                Assert.Fail("Found OOps!!!");

            }
        }
    }
}
