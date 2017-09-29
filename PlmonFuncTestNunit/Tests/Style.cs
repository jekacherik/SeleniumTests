using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using PlmonFuncTestNunit.PageObjects;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using PlmonFuncTestNunit.TestsInputData;
using System.Collections.Generic;

namespace PlmonFuncTestNunit.Tests
{
    [TestFixture]

    //[Parallelizable]
    public class Style : PropertiesCollection
    {
        //private string title;

        //public string existingWindowHandle { get; private set; }

        [Test, Category("Function tests Style")]
        [TestCaseSource("StyleData")]
        public void CheckOpenStyle(string browserName, string user)
        {
            
            //var user = ExelUnit.GetDataFromSheet(_config.TestDataSheetPath, "Login",1,"User");
            //var browserName = ExelUnit.GetDataFromSheet(_config.TestDataSheetPath, "Login", 1, "BrowserName");

            //Init Driver go to URL and check is Login user
            SetUp(browserName, user);
            // Go To Style Folder
            var pageStyle = _pages.GetPage<PageObjectStyle>();
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
            SetUp(browserName,user);

            // Go To Style Folder
            var pageStyle = _pages.GetPage<PageObjectStyle>(); 
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
            var pageNew = _pages.GetPage<StyleNEWPageObjects>(); 

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

        public static IEnumerable<TestCaseData> StyleData
        {
            get
            {
                List<TestCaseData> testCaseDataList = new ExelUnit().ReadExcelData(@"C:\VS projects\PlmonFuncTestNunit\PlmonFuncTestNunit\TestsInputData\TestData.xlsx");
                if (testCaseDataList != null)
                    foreach (TestCaseData testCaseData in testCaseDataList)
                        yield return testCaseData;
            }
        }
    }

}
