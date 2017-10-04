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
using PlmonFuncTestNunit.Base_Classes;

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
           
            //Init Driver go to URL
            SetUp(browserName, user);

            // Go To Style Folder
            var pageStyle = _pages.GetPage<PageObjectStyle>();
            _reportingTasks.Log(Status.Info, "UserAuto go to Style Folder " + driver.Url);
            pageStyle.OpenStyle();

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
        [TestCaseSource("StyleData")]
        public void CheckCreateStyle(String browserName, String user)
        {
            //Init Driver go to URL
            SetUp(browserName,user);
            SeleniumGetMethod.WaitForPageLoad(driver);
            // Go To Style Folder
            var pageStyle = _pages.GetPage<PageObjectStyle>();
            _reportingTasks.Log(Status.Info, "UserAuto go to Style Folder " +"<br>"+driver.Url+"</br>");
            pageStyle.OpenStyle();

            //Go to Style New
            var pageNew = _pages.GetPage<PageObjectStyle>().ClickNewStyle(); 
            //Check page New Header
            pageNew.CheckValidators();

        }

        public static IEnumerable<TestCaseData> StyleData
        {
            get
            {
                List<TestCaseData> testCaseDataList = new ExelUnit().ReadExcelData(@"C:\VS projects\PlmonFuncTestNunit\PlmonFuncTestNunit\TestsInputData\TestData.xlsx","Login");
                if (testCaseDataList != null)
                    foreach (TestCaseData testCaseData in testCaseDataList)
                        yield return testCaseData;
            }
        }
    }

}
