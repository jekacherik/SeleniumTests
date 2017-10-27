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
using OpenQA.Selenium.Interactions;
using PlmonFuncTestNunit.TestsInputData.Style;

namespace PlmonFuncTestNunit.Tests
{
    //[TestFixture("ie", "ET")]
    //[TestFixture("Edge", "ET")]
    [TestFixture("Chrome", "ET")]
    //[Parallelizable]
    public class Style : PropertiesCollection
    {
        //private string title;
        public Style(string browserName, string user) : base(browserName, user) { }

        //public string existingWindowHandle { get; private set; }
        List<string> dataItems = new List<string>();

        [Test, Category("Function tests Style")]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.GetInputDataForTest))]
        public void CheckOpenStyle(InputData dataInput)
        {

            //Init Driver go to URL
            //SetUp(browserName, user);
            // Go To Style Folder
            if (!string.IsNullOrEmpty(dataInput.ReadingDataError)) Assert.Fail(dataInput.ReadingDataError);
            if (!string.IsNullOrEmpty(dataInput.IgnoreReason)) Assert.Ignore(dataInput.IgnoreReason);

            var pageStyle = _pages.GetPage<PageObjectStyle>();

            _reportingTasks.Log(Status.Info, "<b>UserAuto go to Style Folder</b> " + driver.Url);
            pageStyle.OpenStyle();
            pageStyle.CheckSearchMenu(dataInput);
            pageStyle.DragDrop();

            //pageStyle.CkeckExcelBtn();
            pageStyle.CkeckSortGrid();


            //var pageStyleInside = _pages.GetPage<PageObjectStyle>().Style();
            //_reportingTasks.Log(Status.Info, "<b>UserAuto open Style</b>" + driver.Url);
            //Thread.Sleep(5000);

            //driver.SwitchTo().Window(pageStyleInside.WindowHandle).Close();




        }

        [Test, Category("Function tests Style")]
        //[TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.GetStyleHeadersData))]
        public void CheckExistsValidatorCreateStyle()
        {
            //Init Driver go to URL
            //SetUp(browserName,user);

            //Insert Data for Login Table in DB
            _reportingTasks.Log(Status.Debug, "INSERT VALUE TO LOGIN TABLE ");
            PostGreSQL pgTest = new PostGreSQL();
            //pgTest.PostgreTestInsert();
            //Select from Login Table in DB
            //dataItems = pgTest.PostgreSQLtest1();

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

        [Test, Category("Function tests Style")]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.GetStyleHeadersData))]
        public void CheckCreateStyle(StyleHeaderData data)
        {


            SeleniumGetMethod.WaitForPageLoad(driver);
            // Go To Style Folder
            var pageStyle = _pages.GetPage<PageObjectStyle>();
            _reportingTasks.Log(Status.Info, "UserAuto go to Style Folder " + "<br>" + driver.Url + "</br>");
            pageStyle.OpenStyle();

            //Go to Style New
            var pageNew = _pages.GetPage<PageObjectStyle>().ClickNewStyle();
            //Check page New Header
            pageNew.Createpage(data);
            driver.SwitchTo().Window(pageNew.WindowHandle).Close();
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
    public class TestDataSource
    {
        private static string XmlFileName { get; set; }
        static TestDataSource()
        {
            var testsConfig = TestsConfiguration.Instance;
            

            string pathGl = Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().CodeBase);
            string path = pathGl.Substring(0, pathGl.IndexOf("bin")) + ("TestsInputData\\XMLData\\TestsCasesData.xml");
            string projectPth = new Uri(path).LocalPath;

            XmlFileName = projectPth;
            _getInputDataForTest = TestCasesDataLoader.Load<InputData>(XmlFileName, nameof(Style.CheckOpenStyle));
            _getStyleHeadersData = TestCasesDataLoader.Load<StyleHeaderData>(XmlFileName, nameof(Style.CheckCreateStyle));
        }
        private static Func<IEnumerable<TestCaseData>> _getInputDataForTest;
        public static IEnumerable<TestCaseData> GetInputDataForTest() => _getInputDataForTest();
        private static Func<IEnumerable<TestCaseData>> _getStyleHeadersData;
        public static IEnumerable<TestCaseData> GetStyleHeadersData() => _getStyleHeadersData();

    }
}
