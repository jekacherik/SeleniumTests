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
using PlmonFuncTestNunit.DB_connectors;
using PlmonFuncTestNunit.Helpers;
using System.IO;
using System.Threading;

namespace PlmonFuncTestNunit.Tests
{
    [TestFixture]

    //[Parallelizable]
    public class Style : PropertiesCollection
    {
        //private string title;

        //public string existingWindowHandle { get; private set; }
        List<string> dataItems = new List<string>();

        [Test, Category("Function tests Style"),Description("Open Style Tests")]
        [TestCaseSource("StyleData")]
        public void CheckOpenStyle(string browserName, string user)
        {
           
            //Init Driver go to URL
            SetUp(browserName, user);

            // Go To Style Folder
            var pageStyle = _pages.GetPage<PageObjectStyle>();

            _reportingTasks.Log(Status.Info, "<b>UserAuto go to Style Folder</b> " + driver.Url);
            pageStyle.OpenStyle();

            //pageStyle.CkeckExcelBtn();
            pageStyle.CkeckSortGrid();


            var pageStyleInside = _pages.GetPage<PageObjectStyle>().Style();
            _reportingTasks.Log(Status.Info, "<b>UserAuto open Style</b>" + driver.Url);
            Thread.Sleep(5000);

            driver.SwitchTo().Window(pageStyleInside.WindowHandle).Close();
            



        }

        [Test, Category("Function tests Style")]
        [TestCaseSource("StyleData")]
        public void CheckCreateStyle(String browserName, String user)
        {
            //Init Driver go to URL
            SetUp(browserName,user);

            //Insert Data for Login Table in DB
            _reportingTasks.Log(Status.Debug, "INSERT VALUE TO LOGIN TABLE ");
            PostGreSQL pgTest = new PostGreSQL();
            pgTest.PostgreTestInsert();
            //Select from Login Table in DB
            dataItems = pgTest.PostgreSQLtest1();

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
                string pathGl = Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().CodeBase);
                string path = pathGl.Substring(0, pathGl.IndexOf("bin")) + ("TestsInputData\\TestData.xlsx");
                string projectPth = new Uri(path).LocalPath;

                List<TestCaseData> testCaseDataList = new ExelUnit().ReadExcelData(projectPth, "Login");
                if (testCaseDataList != null)
                    foreach (TestCaseData testCaseData in testCaseDataList)
                        yield return testCaseData;
            }
        }
    }

}
