//using AventStack.ExtentReports;
//using NUnit.Framework;
//using System;
//using PlmonFuncTestNunit.PageObjects;
//using System.Linq;
//using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium;
//using System.Collections.ObjectModel;
//using PlmonFuncTestNunit.TestsInputData;
//using System.Collections.Generic;
//using PlmonFuncTestNunit.Base_Classes;
//using PlmonFuncTestNunit.DB_connectors;
//using PlmonFuncTestNunit.Helpers;
//using System.IO;

//namespace PlmonFuncTestNunit.Tests
//{
//    [TestFixture]
//    [Ignore("Ignore a test")]
//    //[Parallelizable]
//    public class Image : PropertiesCollection
//    {
//        //private string title;

//        //public string existingWindowHandle { get; private set; }
//        List<string> dataItems = new List<string>();

//        [Test, Category("Function tests Image"), Description("Open Image Tests")]
//        [TestCaseSource("StyleData")]
//        public void CheckOpenImageFolder(string browserName, string user)
//        {

//            //Init Driver go to URL
//            SetUp(browserName, user);
//            // Go To Image Folder and try check search
//            var pageImage = _pages.GetPage<PageObjectImage>();
//            _reportingTasks.Log(Status.Info, "UserAuto go to Iamge Folder " + driver.Url);
//            pageImage.OpenImage();
           
//            new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(3000)).Until(ExpectedConditions.ElementToBeClickable((By.Id(pageImage.BtnSearch.GetAttribute("Id")))));
//            for(int i =0; i < pageImage.AllTextBoxes.Count-1; i++)
//            {  
//                pageImage.AllTextBoxes[i].EnterText(Randomizer.String(6));
//            }

//                Scrolling.ScrollToElement("#imgBtnSearch");
//                System.Threading.Thread.Sleep(3000);
//        }










//        public static IEnumerable<TestCaseData> StyleData
//        {
//            get
//            {
//                string pathGl = Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().CodeBase);
//                string path = pathGl.Substring(0, pathGl.IndexOf("bin")) + ("TestsInputData\\TestData.xlsx");
//                string projectPth = new Uri(path).LocalPath;

//                List<TestCaseData> testCaseDataList = new ExelUnit().ReadExcelData(projectPth, "Login");
//                if (testCaseDataList != null)
//                    foreach (TestCaseData testCaseData in testCaseDataList)
//                        yield return testCaseData;
//            }
//        }
//    }

//}
