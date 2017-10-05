﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using PlmonFuncTestNunit.Base_Classes;
using OpenQA.Selenium.Support.Extensions;
using PlmonFuncTestNunit.PageObjects;
using PlmonFuncTestNunit.TestsInputData;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Events;
using System.Drawing.Imaging;

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
        //protected ExtentReports _extent;
        //protected ExtentTest _test;
        public static IWebDriver driver;
        protected TestsConfiguration _config = null;
        protected PagesManager _pages = null;
        public static ReportingTasks _reportingTasks;



        [OneTimeSetUp]
        protected void StartReport()
        {
 
            _config = TestsConfiguration.Instance;


            ExtentReports extentReports = ReportingManager.Instance;

            _reportingTasks = new ReportingTasks(extentReports);



        }

        public void SetUp(String browserName, String user)
        {


            //Init test Name to log
            _reportingTasks.InitializeTest();

            //Init Web driver  
            driver = WebDriverFactory.GetWebDriver(browserName);
            EventFiringWebDriver firingDriver = new EventFiringWebDriver(driver);
            firingDriver.ExceptionThrown += firingDriver_TakeScreenshotOnException;
            //firingDriver.ElementClicked += firingDriver_Cliked;
            firingDriver.Navigated += firingDriver_Navigate;
            driver = firingDriver;

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
            _reportingTasks.SaveReport();
        }
        public void IsLogin(String user)
        {
            //Go to Desk Page
            _reportingTasks.CreateNode("User Authorization action");
            Goto(_config.PlmUrl);
            SeleniumGetMethod.WaitForPageLoad(driver);
            //If User not login 
            if (driver.Url.IndexOf("/BI/BI_Main.aspx", StringComparison.OrdinalIgnoreCase) == -1)
            {
                SeleniumGetMethod.WaitForPageLoad(driver);
                //Go to Login page
                driver.Navigate().GoToUrl(_config.PlmUrlDef);
                var pagelogin = _pages.GetPage<LoginPageObjects>();

                //Get data for test User from Test and pass in config 
                pagelogin.Login(user, _config.Password);

                _reportingTasks.Log(Status.Info, user + " Login in the system");
                SeleniumGetMethod.WaitForPageLoad(driver);
            }
            else
            {
                //if (InternetExplorerDriver )
                //{
                //    driver.ExecuteJavaScript(@"window.onbeforeunload = function(){}");
                //}

            }
        }

        public static void Goto(string url)
        {
            driver.Navigate().GoToUrl(url);
            //driver.Url = url;
        }
        public static string Title
        {
            get { return driver.Title; }
        }
        public static IWebDriver getDriver
        {
            get { return driver; }
        }
        private static void firingDriver_TakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            driver.TakeScreenshot().SaveAsFile("Exception-" + timestamp + ".png");
            _reportingTasks.Log(Status.Warning, "Exception"+ sender);
        }

        private static void firingDriver_Cliked(object sender, WebElementEventArgs e)
        {
            
            _reportingTasks.Log(Status.Skip, "User ClickedElements ");
        }
        private static void firingDriver_Navigate(object sender, WebDriverNavigationEventArgs e)
        {
            _reportingTasks.Log(Status.Info, "Navigate to URL "+ driver.Url);

            if(driver.Url.IndexOf("/CustomError.aspx", StringComparison.OrdinalIgnoreCase) != -1)
            {
                _reportingTasks.Log(Status.Error, "Found OOPs page!!!");
            }
        }

        [TearDown]
        public void Cleanup()
        {
            _reportingTasks.FinalizeTest(driver);
            driver.Quit();
            driver.Dispose();
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
            new object[] { "Chrome","ET"},
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
