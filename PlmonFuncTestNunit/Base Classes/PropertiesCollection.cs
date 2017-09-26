using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using PlmonFuncTestNunit.Base_Classes;
using OpenQA.Selenium.Support.Extensions;
using PlmonFuncTestNunit.PageObjects;

namespace PlmonFuncTestNunit
{
    enum PropertyType
    {
        Id,
        Name,
        CssName,
        ClassName,
        Xpath

    }

    public class PropertiesCollection : GetSreenShot
    {
        //Auto-implemented property
        protected ExtentReports _extent;
        protected ExtentTest _test;
        public static IWebDriver driver;
        protected TestsConfiguration _config = null;
        protected PagesManager _pages = null;


        [OneTimeSetUp]
        protected void StartReport()
        {
 
            _config = TestsConfiguration.Instance;
            //Setting project path
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.IndexOf("bin"));
            string projectPth = new Uri(actualPath).LocalPath;


            var dir = TestContext.CurrentContext.TestDirectory + "Reports\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(projectPth + "\\Reports\\" + fileName);
            htmlReporter.Configuration().ReportName = "Plmon function Tests";
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);


        }

        public void SetUp(String browserName, String user)
        {

            //Init test Name to log
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //Init Web driver  
            driver = WebDriverFactory.GetWebDriver(browserName);
            driver.Manage().Timeouts().ImplicitWait = _config.ImplicitlyWait;
            driver.Manage().Timeouts().PageLoad = _config.PageLoadWait;
            //init Page Manager 
            _pages = new PagesManager(driver);
            //Checking user authorization 
            IsLogin(user);


        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }
        public void IsLogin(String user)
        {
            //Go to Desk Page
            Goto(_config.PlmUrl);
            //If User not login 
            if (driver.Url.IndexOf("/BI/BI_Main.aspx", StringComparison.OrdinalIgnoreCase) == -1)
            {
                //Go to Login page
                driver.Navigate().GoToUrl(_config.PlmUrlDef);
                var pagelogin = _pages.GetPage<LoginPageObjects>();
                //Get data for test User from Test and pass in config 
                pagelogin.Login(user, _config.Password);
                _test.Log(Status.Info, user+" Login in the system");
                _extent.Flush();
            }
            else
            {
                _test.Log(Status.Info, "User already logged In ");
                _extent.Flush();
                driver.ExecuteJavaScript(@"window.onbeforeunload = function(){}");
            }
        }
        public static void Goto(string url)
        {
            driver.Url = url;
        }
        public static string Title
        {
            get { return driver.Title; }
        }
        public static IWebDriver getDriver
        {
            get { return driver; }
        }
        [TearDown]
        public void Cleanup()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var sreenName = this.GetType().ToString() + ".png";
            string actualPath = pth.Substring(0, pth.IndexOf("bin")) + ("Reports\\Screens\\" + sreenName);
            string projectPth = new Uri(actualPath).LocalPath;

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMassege = TestContext.CurrentContext.Result.Message;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            string screenShotPath;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    screenShotPath = Capture(driver, "testScreen");
                    _test.Log(logstatus, "See screen below !!! " + _test.AddScreenCaptureFromPath(screenShotPath));
                    _extent.Flush();
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + errorMassege+ stacktrace);         
            _extent.Flush();
            driver.Quit();
        }

        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = TestsInputData.AutomationSettings.BrowserToRunWith.Split(',');
            String[] users = TestsInputData.AutomationSettings.Users.Split(',');

            foreach (String b in browsers)
            {
                yield return b;
 
            }

        }

        static object[] BrowserUser =
        {
            //new object[] { "ie","ET"},
            new object[] { "Edge", "userSel" },
            new object[] { "Chrome","UserET"}
        };
        static object[] BrowserUserControlPanel =
        {
            //new object[] { "Edge", "userSel" },
            //new object[] { "ie","ET"}
            new object[] { "Chrome","ET"}


        };
        static object[] BrowserStyle =
        {
            new object[] { "Chrome", "UserET"},
            //new object[] { "ie","ET"}
            //new object[] { "Edge", "userSel" }

        };
        static object[] BrowserLogin =
        {
            //new object[] { "Chrome", "veryyyyyyyylonnnnnnnnnnnnnnnggggggggggggggggguuuuuuuseeeeeerrrrrrNammmmmmmmmmme","plmon1234@"},
            new object[] { "ie","ET","plmon1234@111"}
            //new object[] { "Edge", "ET", "!@$^$$%^%&^^*&(*(*)())()))_++" }

        };


    }

}
