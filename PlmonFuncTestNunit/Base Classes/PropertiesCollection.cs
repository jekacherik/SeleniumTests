using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlmonFuncTestNunit.Base_Classes;
using System.Drawing;
using OpenQA.Selenium.Support.Events;

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
    //[SetUpFixture]
    public class PropertiesCollection : GetSreenShot
    {
        //Auto-implemented property
        protected ExtentReports _extent;
        protected ExtentTest _test;
        public static IWebDriver driver;
         
        //public static Base_Classes.ReportsManager reports;

        [OneTimeSetUp]
        protected void StartReport()
        {
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
        static void firingDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Console.WriteLine(e.ThrownException.Message);
        }

        static void firingDriver_ElementClicked(object sender, WebElementEventArgs e)
        {
            Console.WriteLine(e.Element);
            string URL = driver.Url;
            Char delimiter = '?';
            String[] substrings = URL.Split(delimiter);
            var parseUrl = substrings[0];
            if (parseUrl == "http://uiprototype80.dyn.yuniquecloud.com/plmOn/CustomError.aspx")
            {
                Assert.Fail("Found OOps!!!");
            }
        }

        static void firingDriver_FindElementCompleted(object sender, FindElementEventArgs e)
        {
            Console.WriteLine(e.FindMethod);
        }
        ////[OneTimeSetUp]

        public void SetUp(String browserName)
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            var firingDriver = new EventFiringWebDriver(driver);
            firingDriver.ExceptionThrown +=
                new EventHandler<WebDriverExceptionEventArgs>(firingDriver_ExceptionThrown);

            firingDriver.ElementClicked +=
                new EventHandler<WebElementEventArgs>(firingDriver_ElementClicked);

            firingDriver.FindElementCompleted +=
                new EventHandler<FindElementEventArgs>(firingDriver_FindElementCompleted);

            driver = firingDriver;
            switch (browserName)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    driver.Manage().Window.Size = new Size(1024, 768);
                    //driver.Manage().Window.Maximize();
                    break;
                case "ie":
                    InternetExplorerOptions ieoptions = new InternetExplorerOptions();
                    ieoptions.IntroduceInstabilityByIgnoringProtectedModeSettings = false;
                    driver = new InternetExplorerDriver(ieoptions);
                    driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    driver.Manage().Window.Size = new Size(1920, 1080);
                    break;
                //case "Firefox":
                //    driver = new FirefoxDriver();
                //    break;
            }
            //driver.Manage().Window.Maximize();
            //reports = new Base_Classes.ReportsManager(browserName, TestsInputData.AutomationSettings.BaseUrl);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMinutes(10));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromMinutes(10));
            Goto(TestsInputData.AutomationSettings.BaseUrl);


        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }

        public static void Goto(string url)
        {
            driver.Url = url;
            //reports.verifyURL(url);
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
            new object[] { "Edge", "userSel" },
            //new object[] { "ie","ET"}
            //new object[] { "Chrome","ET"}


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
            //new object[] { "ie","!@$^$$%^%&^^*&(*(*)())()))_++","veryyyyyyyylonnnnnnnnnnnnnnnggggggggggggggggguuuuuuuseeeeeerrrrrrPaaaaaaaaaaaassss"},
            new object[] { "Edge", "ET", "!@$^$$%^%&^^*&(*(*)())()))_++" }

        };


    }

}
