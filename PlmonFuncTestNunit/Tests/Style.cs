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
using System.Collections.ObjectModel;

namespace PlmonFuncTestNunit.Tests
{
    [TestFixture]

    //[Parallelizable]
    public class Style : PropertiesCollection
    {
        //private string title;

        //public string existingWindowHandle { get; private set; }

        [Test, Category("Function tests Style")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserStyle")]
        public void CheckOpenStyle(String browserName, String user)
        {
            //Init Driver go to URL
            System.Threading.Thread.Sleep(1000);
            SetUp(browserName);
            System.Threading.Thread.Sleep(10000);

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

        [Test, Category("Function tests Style")]
        [TestCaseSource(typeof(PropertiesCollection), "BrowserStyle")]
        public void CheckCreateStyle(String browserName, String user)
        {
            //Init Driver go to URL
            System.Threading.Thread.Sleep(3000);
            SetUp(browserName);
            System.Threading.Thread.Sleep(10000);

            //Login in the System
            LoginPageObjects pagelogin = new LoginPageObjects();
            //Get data for test in xml
            pagelogin.Login(user, TestsInputData.AutomationSettings.Password);

            //Add info to the Log
            _test.Log(Status.Info, "UserAuto Login in the system");
            _extent.Flush();

            // Go To Style Folder
            PageObjectStyle pageStyle = new PageObjectStyle();
            _test.Log(Status.Info, "UserAuto go to Style Folder " + driver.Url);
            _extent.Flush();
            pageStyle.btnStyleDesk.Click();
            System.Threading.Thread.Sleep(3000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementExists((By.Id("lblHeader"))));
            Assert.AreEqual("Style Folder", pageStyle.lblHeader.Text, "Text not found!!!");

            // Go to Create Style Page
            pageStyle.btnNew.Click();

            //Select to NEW TAB 
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            _test.Log(Status.Info, "UserAuto SwitchTo " + driver.Url);
            _extent.Flush();

            System.Threading.Thread.Sleep(5000);
            StyleNEWPageObjects pageNew = new StyleNEWPageObjects();

            //Check page New Header
            var textHeaderNew = pageNew.NewPagelblHeader.Text;
            Assert.AreEqual("New Style...", textHeaderNew, "Text not found!!!");
            _test.Log(Status.Info, "UserAuto Open the Style Create Page " + textHeaderNew + driver.Url);
            _extent.Flush();
            pageNew.btnNext.Click();
            _test.Log(Status.Info, "UserAuto Click the btnNext " + textHeaderNew + driver.Url);
            System.Threading.Thread.Sleep(3000);

            //Check Validators
            new WebDriverWait(driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementIsVisible((By.Id("ctl07"))));
            pageNew.error_icon.Click();
            bool isValidatorDisplayed = pageNew.error_icon.Displayed;
            Assert.AreEqual(true, isValidatorDisplayed, "Validator wasn't find");

            string screenShotPath;
            screenShotPath = Capture(driver, "testScreen");
            _test.Log(Status.Info, "Check present the Validators on the Page " + _test.AddScreenCaptureFromPath(screenShotPath));

            //Click btn Close
            pageNew.btnClose.Click();
            _test.Log(Status.Info, "UserAuto click button Close");
            _extent.Flush();
        }


    }
}
